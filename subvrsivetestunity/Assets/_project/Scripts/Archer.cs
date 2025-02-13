using UnityEngine;

public class Archer : BaseCharacter
{
    [SerializeField]
    private GameObject _weaponPrefab;

    public override void Init()
    {
        base.Init();
        Health = 5;
        MoveSpeed = 5;
        RotateSpeed = 5;
        Weapon = _weaponPrefab.GetComponent<BaseWeapon>();
    }
}