using UnityEngine;

public class IdleState : UnitState
{
    public IdleState(BaseCharacter baseCharacter, UnitStateMachine unitStateMachine) : base(baseCharacter, unitStateMachine)
    {
        _character = baseCharacter;
        _stateMachine = unitStateMachine;
    }

    public override void Enter()
    {
        Debug.Log($"{_character.name} has entered the {this.GetType().Name} state.");
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
    }
}

