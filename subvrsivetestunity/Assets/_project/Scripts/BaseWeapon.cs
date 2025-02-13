using UnityEngine;

public  class BaseWeapon : MonoBehaviour, IWeapon
{
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }
    public float Damage { get => _damage; set => _damage = value; }
    public float AttackCooldown { get => attackCooldown; set => attackCooldown = value; }

    protected float _attackSpeed = 1;
    protected float _damage = 1;
    private float attackCooldown = 0;
}