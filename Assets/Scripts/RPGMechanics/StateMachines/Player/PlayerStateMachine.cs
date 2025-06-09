using RPGMechanics.Characters.Player;
using RPGMechanics.Input;
using RPGMechanics.Weapons;

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
            SwitchState(new PlayerFreeLookState(this));
        }
    }
}