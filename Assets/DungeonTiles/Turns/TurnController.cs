using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonTiles.Turns
{
    /// <summary>
    /// Keeps track of whose turn it is and what phase of the turn it's in.
    /// </summary>
    public class TurnController
    {
        public Turn Turn { get; set; }

        public TurnController()
        {
            Turn = new Turn(0);
        }
    }
}
