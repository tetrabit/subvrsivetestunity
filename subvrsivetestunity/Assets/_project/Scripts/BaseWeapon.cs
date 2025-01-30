public abstract class BaseWeapon : IWeapon
{
    public float AttackSpeed { get => _attackSpeed; set => _attackSpeed = value; }

    private float _attackSpeed = 10;
}