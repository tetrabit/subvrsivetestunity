using UnityEngine;

public class BaseRangedWeapon : BaseWeapon, IRangedWeapon
{
    public float Range { get => _range; set => _range = value; }
    public IProjectile AmmoType { get => _ammoType; set => _ammoType = value as BaseProjectile; }
    public GameObject ProjectilePrefab { get => _projectilePrefab; set => _projectilePrefab = value; }

    protected float _range = 10f;
    protected BaseProjectile _ammoType;
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private Transform _projectileSpawnTransform;
    private float _attackTimer = 0f;

    private void Update()
    {
        if (_attackTimer > 0)
        {
            _attackTimer -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if (_attackTimer > 0) return;

        _attackTimer = _attackSpeed;

        var projectile = ObjectPool.Instance.SpawnFromPool(_projectilePrefab, 
            _projectileSpawnTransform.position, 
            _projectileSpawnTransform.rotation)
            .GetComponent<BaseProjectile>();

        projectile.Fire();
    }
}
