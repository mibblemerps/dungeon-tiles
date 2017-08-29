using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonTiles.Util.Fsm
{
    /// <summary>
    /// Represents a state possible in a finite state machine.
    /// </summary>
    public class State
    {
        protected FiniteStateMachine Fsm;

        public State(FiniteStateMachine fsm)
        {
            Fsm = fsm;
        }

        /// <summary>
        /// Executed when we switched to this state.
        /// </summary>
        public virtual void Start() { }

        /// <summary>
        /// Updated once every frame that this state is active.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Executed as a new state is being set.
        /// </summary>
        public virtual void End() { }
    }
}
