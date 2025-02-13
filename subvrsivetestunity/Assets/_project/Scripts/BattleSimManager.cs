using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleSimManager : MonoBehaviourSingleton<BattleSimManager>
{
    public List<BaseCharacter> Units { get => _units; set => _units = value; }

    private List<BaseCharacter> _units = new List<BaseCharacter>();
    private int _numUnits = 10;
    [SerializeField]
    private GameObject _unitPrefab;

    protected override void Awake()
    {
        SpawnArchers();
        CacheObjects();
    }

    private void SpawnArchers()
    {
        for (int i = 0; i < _numUnits; i++)
        {
            var spawnPos = new Vector3(RandomUtil.Instance.Next(-100, 100), 0f, 
                RandomUtil.Instance.Next(-100, 100));

            var UnitObject = Instantiate(_unitPrefab, spawnPos, Quaternion.identity);

            BaseCharacter unit = UnitObject.GetComponent<BaseCharacter>();
            unit.Init();

            if (unit != null)
            {
                unit.State.ChangeState(unit.TargetState);
                _units.Add(unit);
            }
        }
    }

    private void CacheObjects()
    {
        foreach (var unit in _units)
        {
            for (int i = 0; i < 10; i++)
            {
                if(unit.Weapon is BaseRangedWeapon rangedWeapon)
                {
                    var weaponObject = Instantiate(rangedWeapon.ProjectilePrefab, 
                        ObjectPool.POOL_LOCATION, Quaternion.identity);
                    ObjectPool.Instance.ReturnToPool(weaponObject);
                }
            }
        }
    }

    private void OnEnable()
    {
        Events.CharacterDied += OnUnitDied;
        Events.UnitHit += OnUnitHit;
    }

    private void OnDisable()
    {
        Events.CharacterDied -= OnUnitDied;
        Events.UnitHit -= OnUnitHit;
    }

    private void OnUnitDied(BaseCharacter character)
    {
        if (character is null) return;

        if(_units.Count == 1) return;

        if(_units.Contains(character))
        {
            character.State.ChangeState(character.DeadState);
            _units.Remove(character);
        }
    }

    private void OnUnitHit(BaseCharacter unit, float damage)
    {
        if (unit is null) return;

        CheckForWinner();

        unit.Health -= damage;

        if (unit.Health <= 0)
        {
            Events.RaiseCharacterDied(unit);
        }
    }

    private void Update()
    {
        CheckForWinner();

        foreach (var unit in _units)
        {
            unit.State.Update();
        }
    }

    private void CheckForWinner()
    {
        if (_units.Count == 1)
        {
            _units[0].Health = 9999f;
            _units[0].IsAlive = true;
            Debug.Log($"the winner is {_units[0].Name}");
        }
    }
    
    public static class Events
    {
        public static event Action<BaseCharacter> CharacterDied;

        public static void RaiseCharacterDied(BaseCharacter character)
        {
            CharacterDied?.Invoke(character);
        }

        public static event Action<BaseCharacter, float> UnitHit;

        public static void RaiseUnitHit(BaseCharacter unit, float damage)
        {
            UnitHit?.Invoke(unit, damage);
        }
    }
}
