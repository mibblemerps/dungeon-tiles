using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonTiles.Turns
{
    public class Turn
    {
        private TurnPhase _turnPhase = TurnPhase.Hero;
        private int _currentPlayersTurnIndex = 0;

        /// <summary>
        /// Get/set the whose turn it currently is.
        /// This player must exist in the game player list, otherwise bad things will happen.
        /// </summary>
        public Player CurrentPlayersTurn
        {
            get { return Game.Instance.Players[_currentPlayersTurnIndex]; }
            protected set
            {
                _currentPlayersTurnIndex = Game.Instance.Players.FindIndex((playerBehaviour) => { return playerBehaviour == value; });
            }
        }

        /// <summary>
        /// Set the current turn phase.
        /// </summary>
        public TurnPhase TurnPhase
        {
            get { return _turnPhase; }
            protected set { _turnPhase = value; }
        }

        /// <summary>Moves made</summary>
        public int Moves = 0;
        /// <summary>Attacks performed. Under normal rules this can never be more than 1.</summary>
        public int Attacks = 0;

        public Turn(Player player)
        {
            CurrentPlayersTurn = player;
        }

        public Turn(int playerIndex)
        {
            _currentPlayersTurnIndex = playerIndex;
        }
    }
}
