using NUnit.Framework.Constraints;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveState : UnitState
{
    public MoveState(BaseCharacter baseCharacter, UnitStateMachine unitStateMachine) : base(baseCharacter, unitStateMachine)
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
        if (_character.Target == null)
        {
            _character.State.ChangeState(_character.TargetState);
            return;
        }

        var direction = _character.Target.transform.position - _character.transform.position;

        _character.transform.position = Vector3.MoveTowards(
            _character.transform.position,
            _character.Target.transform.position,
            _character.MoveSpeed * Time.deltaTime
            );

        var tolerance = 0.01f;

        if (direction.sqrMagnitude > tolerance)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            _character.transform.rotation = Quaternion.Slerp(
            _character.transform.rotation,
                targetRotation,
                _character.RotateSpeed * Time.deltaTime
            );
        }

        if (UnitUtilities.IsOnTarget(_character))
        {
            _character.State.ChangeState(_character.AttackState);
        }
    }

    public override void Exit()
    {

    }
}

