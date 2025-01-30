public interface IRangedWeapon : IWeapon
{
    public float Range { get; set; }
    public IProjectile AmmoType { get; set;}
    public void Fire();
}
