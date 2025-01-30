using UnityEngine;

public class BaseCharacter : MonoBehaviour, IUnit
{
    public float Health { get => _health; set => _health = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float RotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }
    public IWeapon Weapon { get => _weapon; set => _weapon = value; }

    private float _health = 10;
    private float _moveSpeed = 10;
    private float _rotateSpeed = 10;
    private IWeapon _weapon;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}