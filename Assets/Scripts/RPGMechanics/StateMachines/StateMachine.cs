using RPGMechanics.Characters;

using UnityEngine;

namespace RPGMechanics.StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        
        private State currentState;

        private void Update()
        {
            currentState?.Tick(Time.deltaTime);
        }


        public void SwitchState(State newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
    }
}