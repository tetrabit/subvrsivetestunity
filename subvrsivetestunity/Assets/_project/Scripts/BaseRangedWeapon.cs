public abstract class BaseRangedWeapon : BaseWeapon, IRangedWeapon
{
    public float Range { get => _range; set => _range = value; }
    public IProjectile AmmoType { get => _ammoType; set => _ammoType = value; }

    private float _range = 10;
    private IProjectile _ammoType;

    public void Fire()
    {
        
    }
}
