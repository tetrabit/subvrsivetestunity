using UnityEngine;

public interface IProjectile
{
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float TimeToLive { get; set; }
}
