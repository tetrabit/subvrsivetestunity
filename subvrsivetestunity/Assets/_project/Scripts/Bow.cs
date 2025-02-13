public class Bow : BaseRangedWeapon
{
    public Bow()
    {
        Init();
    }

    public Bow(float range, float attackSpeed, IProjectile projectile)
    {
        Range = range;
        AttackSpeed = attackSpeed;
        AmmoType = projectile;
    }

    public void Init()
    {
        Range = 5;
        AttackSpeed = 2;
        AmmoType = new Arrow();
    }
}