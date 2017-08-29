using UnityEngine;
using UnityEngine.Events;

namespace DungeonTiles.Util.Fsm
{
    /// <summary>
    /// A simple, generic FSM implementation.
    /// </summary>
    public class FiniteStateMachine
    {
        /// <summary>
        /// A simple state that does nothing.
        /// </summary>
        public static State IdleState;

        public StateChangeEvent OnNewState = new StateChangeEvent();

        private State _state = IdleState;

        public FiniteStateMachine()
        {
            IdleState = new State(this);
        }

        /// <summary>
        /// Current state
        /// </summary>
        public State State
        {
            get { return _state; }
            set { SetState(value); }
        }

        public void SetState(State state)
        {
            // End old state
            if (_state != null)
            {
                _state.End();
                Debug.Log("[Fsm] State change: " + _state.ToString() + " -> " + state.ToString());
            }
            else
            {
                Debug.Log("[Fsm] State change: None -> " + state.ToString());
            }

            // Set new state
            _state = state;

            // Allow state to start
            _state.Start();

            // Trigger event
            OnNewState.Invoke(_state);
        }

        /// <summary>
        /// Simply calls the Update method on whatever state is currently active.
        /// </summary>
        public void Update()
        {
            if (State != null)
                State.Update();
        }


        public class StateChangeEvent : UnityEvent<State> { }
    }
}
