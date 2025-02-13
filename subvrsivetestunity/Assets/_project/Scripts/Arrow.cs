public class Arrow : BaseProjectile
{
    public Arrow()
    {
        Init();
    }

    public Arrow(float damage, float speed, float timeToLive)
    {
        Damage = damage;
        Speed = speed;
        TimeToLive = timeToLive;
    }

    public void Init()
    {
        Damage = 4;
        Speed = 10;
        TimeToLive = 10;
    }
}
