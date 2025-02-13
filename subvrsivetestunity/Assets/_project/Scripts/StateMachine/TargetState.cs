using System.Linq;
using UnityEngine;

public class TargetState : UnitState
{
    public TargetState(BaseCharacter baseCharacter, UnitStateMachine unitStateMachine) : base(baseCharacter, unitStateMachine)
    {
        _character = baseCharacter;
        _stateMachine = unitStateMachine;
    }

    public override void Enter()
    {
        Debug.Log($"{_character.name} has entered the {this.GetType().Name} state.");


        var units = BattleSimManager.Instance.Units;
        var validTargets = units.Where(unit => unit != _character).ToList();

        if (validTargets.Count <= 0)
        {
            _character.Target = null;
            _character.State.ChangeState(_character.IdleState);
            return;
        }

        var rand = RandomUtil.Instance.Next(validTargets.Count);
        _character.Target = validTargets[rand];
    }

    public override void Update()
    {
        _character.State.ChangeState(_character.MoveState);
    }
}
