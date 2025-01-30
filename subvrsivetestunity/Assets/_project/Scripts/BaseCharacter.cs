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

    public class CharacterState
    {
        public StateMachine stateMachine;
        public IdleState IdleState = new IdleState();
        public MoveState MoveState = new MoveState();
        public AttackState AttackState = new AttackState();
        public TargetState TargetState = new TargetState();
        public DeadState DeadState = new DeadState();
    }
}

public class Archer : BaseCharacter
{
    StateMachine stateMachine;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        Health = 5;
        MoveSpeed = 5;
        RotateSpeed = 5;
        Weapon = new Bow();
    }
}