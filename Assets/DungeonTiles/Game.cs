using System;
using System.Collections.Generic;
using System.Linq;
using DungeonTiles.Content.Attacks;
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
        
        [HideInInspector]
        public GridController GridController;
        [HideInInspector]
        public TurnController TurnController;

        #endregion

        public List<Player> Players = new List<Player>();

        public Game()
        {
            Instance = this;
        }

        void OnEnable()
        {
            #region GameSystemInitialisers
            GridController = GetComponent<GridController>();
            TurnController = new TurnController();
            #endregion

            Attack.RegisterAttacks();

            LoadPlayers();
        }

        void Start()
        {
            
        }
        
        /* --- */

        /// <summary>
        /// Find all player game objects and add them to the player list.
        /// </summary>
        private void LoadPlayers()
        {
            Players.Clear();

            Player[] players = FindObjectsOfType<Player>();
            foreach (Player player in players)
                Players.Add(player);
        }
    }
}
