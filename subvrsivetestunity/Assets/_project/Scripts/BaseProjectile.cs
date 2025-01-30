public abstract class BaseProjectile : IProjectile
{
    public float Damage { get => _damage; set => _damage = value; }
    public float Speed { get => _speed; set => _speed = value; }

    private float _damage;
    private float _speed;

    public void Fire()
    {

    }
}
