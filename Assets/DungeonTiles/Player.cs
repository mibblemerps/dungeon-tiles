using System;
using System.Collections.Generic;
using DungeonTiles.Grid;
using DungeonTiles.Util;
using UnityEngine;

namespace DungeonTiles
{
    public class Player : MonoBehaviour
    {
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
