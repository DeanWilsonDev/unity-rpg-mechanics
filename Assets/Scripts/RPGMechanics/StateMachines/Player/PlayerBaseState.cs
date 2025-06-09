namespace RPGMechanics.StateMachines.Player
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine stateMachine;

        public PlayerBaseState(PlayerStateMachine stateMachine): base(stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        
    }
}