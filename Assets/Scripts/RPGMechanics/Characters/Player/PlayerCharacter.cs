using System;

using RPGMechanics.Input;
using RPGMechanics.StateMachines.Player;

using Unity.VisualScripting;

using UnityEngine;

using State = RPGMechanics.StateMachines.State;
using StateMachine = RPGMechanics.StateMachines.StateMachine;

namespace RPGMechanics.Characters.Player
{
    public class PlayerCharacter : Character
    {
        [field: SerializeField] public PlayerInventory PlayerInventory { get; private set; }
        [field: SerializeField] public PlayerStateMachine PlayerStateMachine { get; set; }
        [DoNotSerialize] protected override StateMachine StateMachine => PlayerStateMachine; 
        
        public override Inventory Inventory => PlayerInventory;
        
        private void Awake()
        {
            
        }
        

        protected override void Start()
        {
            base.Start();
        }
    }
}