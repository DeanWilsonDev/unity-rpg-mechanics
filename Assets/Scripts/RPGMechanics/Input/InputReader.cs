using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPGMechanics.Input
{
    public class InputReader : MonoBehaviour, InputSystem.IPlayerActions
    
    {
        public event Action JumpEvent;
        public event Action DodgeEvent;
        
        public event Action AttackEvent;
        
        public Vector2 MovementValue { get; private set; }
        public bool IsAttacking { get; set; }

        private InputSystem inputSystem;

        private void Start()
        {
            inputSystem = new InputSystem();
            inputSystem.Player.SetCallbacks(this);

            inputSystem.Player.Enable();
        }

        private void OnDestroy()
        {
            inputSystem.Player.Disable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            JumpEvent?.Invoke();
        }

        public void OnDodge(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            DodgeEvent?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            // Debug.Log("Event Triggered");
            IsAttacking = true;
            AttackEvent?.Invoke();
        }
    }
}