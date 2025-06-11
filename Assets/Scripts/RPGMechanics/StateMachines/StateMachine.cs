using RPGMechanics.Characters;

using UnityEngine;

namespace RPGMechanics.StateMachines
{
    public abstract class StateMachine : MonoBehaviour
    {
        [field: SerializeField] public State CurrentState;

        protected void Update()
        {
            CurrentState?.Tick(Time.deltaTime);
        }

        public void SwitchState(State newState)
        {
            if (newState.GetType() == CurrentState.GetType()) return;
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }
    }
}