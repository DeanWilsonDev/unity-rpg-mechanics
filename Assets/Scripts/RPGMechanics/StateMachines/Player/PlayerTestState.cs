using System;
using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerTestState : PlayerBaseState
    {
        private float timer = 5;

        public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
        }

        public override void Tick(float deltaTime)
        {
            timer -= deltaTime;
            if (timer <= 0) stateMachine.SwitchState(new PlayerTestState(stateMachine));
            Debug.Log(MathF.Floor(timer));
        }

        public override void Exit()
        {
            Debug.Log("Exit");
        }
    }
}