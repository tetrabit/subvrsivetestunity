using JetBrains.Annotations;

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
        Range = 10;
        AttackSpeed = 10;
        AmmoType = new Arrow();
    }
}