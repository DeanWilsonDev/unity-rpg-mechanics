namespace RPGMechanics.StateMachines
{
    public abstract class State
    {

        protected StateMachine stateMachine;

        protected State(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public abstract void Enter();

        public abstract void Tick(float deltaTime);

        public abstract void Exit();

        protected void SwitchState(State newState)
        {
            stateMachine.SwitchState(newState);
        }
    }
}