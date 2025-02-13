using System;
using UnityEngine;

public class BaseCharacter : MonoBehaviour, IUnit
{
    public float Health { get => _health; set => _health = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float RotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }
    public IWeapon Weapon { get => _weapon; set => _weapon = value; }
    public UnitStateMachine State { get => _stateMachine; set => _stateMachine = value; }
    public BaseCharacter Target { get => _target; set => _target = value; }
    public bool IsAlive { get => _isAlive; set => _isAlive = value; }
    public string Name { get => _name; set => _name = value; }

    private float _health = 10;
    private float _moveSpeed = 10;
    private float _rotateSpeed = 10;
    private IWeapon _weapon;
    private BaseCharacter _target;
    private bool _isAlive = true;
    private string _name;

    private UnitStateMachine _stateMachine;
    public IdleState IdleState;
    public MoveState MoveState;
    public AttackState AttackState;
    public TargetState TargetState;
    public DeadState DeadState;

    public virtual void Init()
    {
        _name = NamesQueue.Names.Dequeue();
        StateMachineInit();
    }

    public void StateMachineInit()
    {
        _stateMachine= new UnitStateMachine();
        IdleState = new IdleState(this, _stateMachine);
        MoveState = new MoveState(this, _stateMachine);
        AttackState = new AttackState(this, _stateMachine);
        TargetState = new TargetState(this, _stateMachine);
        DeadState = new DeadState(this, _stateMachine);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0 ) 
        {
            IsAlive = false;
            BattleSimManager.Events.RaiseCharacterDied(this);
        }
    }

    private void Awake()
    {

    }

    private void Start()
    {
    
    }

    private void Update()
    {
        
    }

    public static class Events
    {
        public static event Action<BaseCharacter, float> UnitHit;

        public static void RaiseUnitHit(BaseCharacter unit, float damage)
        {
            UnitHit?.Invoke(unit, damage);
        }
    }
}
