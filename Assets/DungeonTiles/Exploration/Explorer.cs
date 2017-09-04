using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Events;
using DungeonTiles.Turns;
using DungeonTiles.Util;
using UnityEngine;

namespace DungeonTiles.Exploration
{
    public class Explorer : MonoBehaviour
    {
        public GameObject Board;

        protected Game Game;
        protected Generator.Generator Generator;

        public void Start()
        {
            Game = Game.Instance;
            
            Generator = Board.GetComponent<Generator.Generator>();

            GameEvents.OnNewTurnPhase.AddListener((player, turnPhase) =>
            {
                if (turnPhase == TurnPhase.Exploration)
                    PlayerExplore(player);
            });
        }

        /// <summary>
        /// Make a player explore a new tile (if possible)
        /// </summary>
        /// <param name="player">Player to explore</param>
        /// <returns>Was a tile explored?</returns>
        public bool PlayerExplore(Player player)
        {
            Vector3[] directions = VectorHelper.Vector3FlatDirections;
            directions = directions.OrderBy(a => UnityEngine.Random.value).ToArray();

            // Check if there is anything in each direction
            foreach (Vector3 direction in directions)
            {
                Vector3 newPos3 = VectorHelper.RoundVector(player.transform.position) + direction;
                Vector2 newPos = new Vector2(newPos3.x, newPos3.z);

                List<GameObject> objects = Game.GridController.GetObjectsAt(newPos);
                if (objects.Count == 0)
                {
                    // Nothing here, generate tile here.
                    Vector3 pos = GetGameTilePositionFor(newPos);
                    Generator.GenerateTile((int)pos.x, (int)pos.y);

                    return true;
                }
            }

            return false;
        }

        public static Vector3 GetGameTilePositionFor(Vector2 pos)
        {
            return new Vector3(Mathf.Floor(pos.x / 4) * 4,
                Mathf.Floor(pos.y / 4) * 4);
        }
    }
}
