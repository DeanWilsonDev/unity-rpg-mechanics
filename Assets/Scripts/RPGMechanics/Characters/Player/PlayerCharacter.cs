using RPGMechanics.Input;
using RPGMechanics.Inventory;

using UnityEngine;

namespace RPGMechanics.Characters.Player
{
    public class PlayerCharacterInitializer: CharacterInitializer
    {
        public PlayerInventory PlayerInventory { get; set; }
        public InputReader InputReader { get; set; }
        public CharacterController CharacterController { get; set; }
    }
    
    public class PlayerCharacter : Character
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        public override Inventory.Inventory Inventory { get; protected set; }
        [field: SerializeField] public PlayerInventory PlayerInventory { get; private set; }

        public PlayerCharacter InitializeCharacter(PlayerCharacterInitializer initializer)
        {
            base.InitializeCharacter(initializer);

            this.InputReader = initializer.InputReader;
            this.PlayerInventory = initializer.PlayerInventory;
            this.CharacterController = initializer.CharacterController;
            this.Inventory = initializer.PlayerInventory;

            return this;
        }


        private void Awake()
        {
            if (!InputReader) { InputReader = GetComponent<InputReader>(); }

            if (!CharacterController) { CharacterController = GetComponent<CharacterController>(); }
        }


        protected override void Start()
        {
            base.Start();
        }
    }
}