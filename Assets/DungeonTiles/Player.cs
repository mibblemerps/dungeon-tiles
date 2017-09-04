using System;
using System.Collections.Generic;
using DungeonTiles.Grid;
using DungeonTiles.Util;
using UnityEngine;

namespace DungeonTiles
{
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// Is this the local player that this game client is in control of?<br />
        /// This would be false if it's an AI or remote player.
        /// </summary>
        public bool IsLocalPlayer = false;

        protected Game Game;
        protected SmoothMovement GridMovement;

        protected int SquaresMoved = 0;

        void Start()
        {
            Game = Game.Instance;
            GridMovement = GetComponent<SmoothMovement>();
        }

        void Update()
        {
            //
        }
    }
}
