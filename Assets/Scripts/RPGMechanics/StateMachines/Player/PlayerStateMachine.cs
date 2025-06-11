using RPGMechanics.Characters.Player;
using RPGMechanics.Input;

using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        // TODO: This can probably go on the PlayerCharacter
        [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
        [field: SerializeField] public PlayerCharacter PlayerCharacter { get; set; }
        
        public Transform MainCameraTransform { get; private set; }

        private void Awake()
        {
            if (!PlayerCharacter) { PlayerCharacter = GetComponent<PlayerCharacter>(); }
        }
        
        private void Start()
        {
            if (Camera.main)
            {
                MainCameraTransform = Camera.main.transform;
            }

            PlayerCharacter.InputReader.OnAttackEvent += HandleAttack;
            CurrentState = new PlayerFreeLookState(this);
        }

        private void HandleAttack()
        {
            if (PlayerCharacter.InputReader.IsAttacking)
            {
                SwitchState(new PlayerAttackState(this));
            }
        }

        protected void Update()
        {
            base.Update();
        }
    }
}