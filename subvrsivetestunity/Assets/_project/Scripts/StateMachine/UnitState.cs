public class UnitState : IState
{
    protected BaseCharacter _character = null;
    protected UnitStateMachine _stateMachine = null;

    public UnitState(BaseCharacter baseCharacter, UnitStateMachine unitStateMachine)
    {
        _character= baseCharacter;
        _stateMachine = unitStateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
    }
}