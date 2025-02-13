using UnityEngine;

public class BaseProjectile : MonoBehaviour, IProjectile
{
    public float Damage { get => _damage; set => _damage = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public float TimeToLive { get => _timeToLive; set => _timeToLive = value; }

    private float _damage = 4f;
    private float _speed = 10f;
    private float _timeToLive = 10f;
    private float _lifeTimer = 0f;

    public void Fire()
    {
        _lifeTimer = 0f;

        var rigidBody = GetComponent<Rigidbody>();
        if (rigidBody is null) return;

        //transform.right for the sake of this project, in production the axis of the 3D model would need to be changed
        //or utilize scriptable objects for this and have the axis be determined there
        rigidBody.linearVelocity = transform.right * _speed * -1f;
    }

    private void OnEnable()
    {
        _lifeTimer = 0f;
    }

    private void Update()
    {
        _lifeTimer += Time.deltaTime;

        if (_lifeTimer >= _timeToLive)
        {
            ObjectPool.Instance.ReturnToPool(gameObject);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<BaseCharacter>(out BaseCharacter hitCharacter))
        {
            BattleSimManager.Events.RaiseUnitHit(hitCharacter, _damage);
            ObjectPool.Instance.ReturnToPool(gameObject);
        }
    }
}
