using UnityEngine;

public class AttackState : UnitState
{
    public AttackState(BaseCharacter baseCharacter, UnitStateMachine unitStateMachine) : base(baseCharacter, unitStateMachine)
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
        if(_character.Target == null || !_character.Target.IsAlive)
        {
            _character.State.ChangeState(_character.TargetState);
            return;
        }

        var direction = _character.Target.transform.position - _character.transform.position;
        var distance = Vector3.Distance(_character.transform.position, _character.Target.transform.position);

        var rangedWeapon = _character.Weapon as IRangedWeapon;
        var effectiveRange = (rangedWeapon is not null)
            ? rangedWeapon.Range
            : ProjectConstants.MELEE_RANGE;

        if(UnitUtilities.IsOnTarget(_character))
        {
            if (rangedWeapon is not null)
            {
                rangedWeapon.Fire();
            }
        }
        else
        {
            _character.State.ChangeState(_character.MoveState);
        }
    }
}
