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
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        
        public override Inventory Inventory => PlayerInventory;
        
        private void Awake()
        {
            if (!InputReader) { InputReader=GetComponent<InputReader>(); }
            if (!CharacterController) { CharacterController=GetComponent<CharacterController>(); }
        }
        

        protected override void Start()
        {
            base.Start();
        }
    }
}