using RPGMechanics.Input;

using UnityEngine;


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
            if (!InputReader) { InputReader = GetComponent<InputReader>(); }

            if (!CharacterController) { CharacterController = GetComponent<CharacterController>(); }
        }


        protected override void Start()
        {
            base.Start();
        }
    }
}