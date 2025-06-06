using RPGMechanics.Input;

using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerStateMachine : StateMachine
    {
        [field: SerializeField] public InputReader InputReader { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
        
        public Transform MainCameraTransform { get; private set; }
        
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