using UnityEngine;

public class DeadState : UnitState
{
    public DeadState(BaseCharacter baseCharacter, UnitStateMachine unitStateMachine) : base(baseCharacter, unitStateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log($"{_character.name} has entered the {this.GetType().Name} state.");
        if (_character.Health <= 0)
        {
            _character.IsAlive = false;
            _character.transform.localScale = Vector3.zero;
        }

    }

    public override void Update()
    {

    }

    public override void Exit()
    {
    }
}

