using System;

using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerFreeLookState : PlayerBaseState
    {
        public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
           Debug.Log("Enter");
        }

        public override void Tick(float deltaTime)
        {
            Vector3 movement = CalculateMovement();
            stateMachine.PlayerCharacter.CharacterController.Move(movement * (stateMachine.FreeLookMovementSpeed * deltaTime));

            if (stateMachine.PlayerCharacter.InputReader.MovementValue == Vector2.zero)
            {
                stateMachine.PlayerCharacter.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
                return;
            }

            stateMachine.PlayerCharacter.Animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);
            stateMachine.transform.rotation = Quaternion.LookRotation(movement);
        }

        public override void Exit()
        {
            // Debug.Log("Exit");
        }

        private Vector3 CalculateMovement()
        {
            var forward = stateMachine.MainCameraTransform.forward;
            var right = stateMachine.MainCameraTransform.right;

            forward.y = 0;
            right.y = 0;

            forward.Normalize();
            right.Normalize();

            return forward * stateMachine.PlayerCharacter.InputReader.MovementValue.y +
                   right * stateMachine.PlayerCharacter.InputReader.MovementValue.x;
        }
    }
}