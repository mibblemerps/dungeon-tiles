using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DungeonTiles.Events;

namespace DungeonTiles.Turns
{
    /// <summary>
    /// Keeps track of whose turn it is and what phase of the turn it's in.
    /// </summary>
    public class TurnController
    {
        private int _currentPlayerIndex;
        private TurnPhase _turnPhase;

        public List<Player> PlayerList;

        /// <summary>
        /// The current player's index.
        /// </summary>
        public int CurrentPlayerIndex
        {
            get { return _currentPlayerIndex; }
            set
            {
                _currentPlayerIndex = value;
                GameEvents.OnNextTurn.Invoke(CurrentPlayer); // Invoke the next turn event
            }
        }

        /// <summary>
        /// The current player.
        /// </summary>
        public Player CurrentPlayer
        {
            get
            {
                // Get the current player from the player list with the current player index.
                return PlayerList[CurrentPlayerIndex];
            }
            set
            {
                // Search for the newly set player in the player list and set our current player index to it.
                CurrentPlayerIndex = PlayerList.FindIndex((playerBehaviour) => playerBehaviour == value );
            }
        }

        /// <summary>
        /// The current turn phase.
        /// </summary>
        public TurnPhase CurrentPhase
        {
            get { return _turnPhase; }
            set
            {
                TurnPhase oldPhase = _turnPhase;
                _turnPhase = value;
                GameEvents.OnNewTurnPhase.Invoke(CurrentPlayer, _turnPhase);
            }
        }


        public TurnController(List<Player> playerList)
        {
            PlayerList = playerList;

            #region Event Handlers

            // On turn start, set phase to hero phase
            GameEvents.OnNextTurn.AddListener((player) =>
            {
                CurrentPhase = TurnPhase.Hero;
            });

            #endregion

            CurrentPlayer = PlayerList.First();
        }

        public void NextPlayer()
        {
            // Increment the player index, unless we're at the end of the player list, in which case, reset to 0.
            if (CurrentPlayerIndex + 1 >= PlayerList.Count)
                CurrentPlayerIndex = 0;
            else
                CurrentPlayerIndex++;
        }
    }
}
