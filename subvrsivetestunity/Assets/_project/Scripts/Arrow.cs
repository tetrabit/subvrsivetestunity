public class Arrow : BaseProjectile
{
    public Arrow()
    {
        Init();
    }

    public Arrow(float damage, float speed)
    {
        Damage = damage;
        Speed = speed;
    }

    public void Init()
    {
        Damage = 10;
        Speed = 10;
    }
}
