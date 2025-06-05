using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        public PlayerStateMachine PlayerStateMachine { get; set; }

        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            PlayerStateMachine = stateMachine;

        }

        public override void Enter()
        {
            Debug.Log("Attack State Entered");
            PlayerStateMachine.Animator.SetBool(IsAttacking, true);
        }

        public override void Tick(float deltaTime)
        {
            // Add logic for attacking
            
            // - 
            
            Debug.Log("Attack State Tick");
            
            // TODO: A next function would be so much better than this
            PlayerStateMachine.SwitchState(new PlayerFreeLookState(PlayerStateMachine));
        }

        public override void Exit()
        {
            Debug.Log("Attack State Exit");
            PlayerStateMachine.InputReader.IsAttacking = false;
            PlayerStateMachine.Animator.SetBool(IsAttacking, false);
        }
    }
}