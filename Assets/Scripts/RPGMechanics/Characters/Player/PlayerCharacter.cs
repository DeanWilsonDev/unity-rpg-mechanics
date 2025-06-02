using System;

using RPGMechanics.Input;
using RPGMechanics.StateMachines;
using RPGMechanics.StateMachines.Player;

using UnityEngine;

using StateMachine = RPGMechanics.StateMachines.StateMachine;

namespace RPGMechanics.Characters.Player
{
    public class PlayerCharacter : Character
    {
        [field: SerializeField] public PlayerInventory PlayerInventory { get; private set; }
        [field: SerializeField] public PlayerStateMachine PlayerStateMachine { get; set; }
        protected override StateMachine StateMachine => PlayerStateMachine; 
        
        public override State DeathState { get; set; } 
        public override State IdleState { get; set; }
        public override State RunningState { get; set; }
        public override Inventory Inventory => PlayerInventory;
        
        private void Awake()
        {
            DeathState = new PlayerDeathState(PlayerStateMachine);
            
        }
        

        protected override void Start()
        {
            base.Start();
        }
    }
}