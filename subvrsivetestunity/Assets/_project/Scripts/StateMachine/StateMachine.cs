public class StateMachine
{
    public IState CurrentState => _currentState;

    private IState _currentState;

    public void ChangeState(IState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }

    public static class Util
    {
        public static string GetCurrentState(StateMachine stateMachine)
        {
            return stateMachine.CurrentState?.GetType().Name ?? "No state";
        }
    }
}

public class UnitStateMachine : StateMachine
{
    public UnitStateMachine()
    {
        
    }
}
