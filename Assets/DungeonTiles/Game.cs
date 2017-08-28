using System;
using System.Collections.Generic;
using System.Linq;
using DungeonTiles.Events;
using DungeonTiles.Grid;
using DungeonTiles.Turns;
using UnityEngine;

namespace DungeonTiles
{
    /// <summary>
    /// The part that glues the game together.
    /// </summary>
    public class Game : MonoBehaviour
    {
        public static Game Instance;

        #region GameSystems
        public EventSystem EventSystem;
        public GridController GridController;
        public TurnController TurnController;
        #endregion

        public List<PlayerBehaviour> Players = new List<PlayerBehaviour>();

        void OnEnable()
        {
            Instance = this;

            #region GameSystemInitialisers
            EventSystem = GetComponent<EventSystem>();
            GridController = GetComponent<GridController>();
            TurnController = new TurnController();
            #endregion
        }

        void Start()
        {
            LoadPlayers();
        }
        
        /* --- */

        /// <summary>
        /// Find all player game objects and add them to the player list.
        /// </summary>
        private void LoadPlayers()
        {
            Players.Clear();

            PlayerBehaviour[] players = FindObjectsOfType<PlayerBehaviour>();
            foreach (PlayerBehaviour player in players)
                Players.Add(player);
        }
    }
}
