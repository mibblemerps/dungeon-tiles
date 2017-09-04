using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DungeonTiles.Util
{
    public static class VectorHelper
    {
        /// <summary>
        /// Array of all possible Vector2 directions (diagonals not included).
        /// </summary>
        public static Vector2[] Vector2Directions = {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        /// <summary>
        /// Array of all possible Vector3 directions (diagonals not included).<br />
        /// </summary>
        public static Vector3[] Vector3Directions =
        {
            Vector3.up,
            Vector3.down,
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        /// <summary>
        /// Array of all possible Vector3 directions, not including up and down (Y-axis) (diagonals not included).<br />
        /// </summary>
        public static Vector3[] Vector3FlatDirections =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        public static Vector3 RoundVector(Vector3 vector)
        {
            return new Vector3(
                Mathf.Round(vector.x),
                Mathf.Round(vector.y),
                Mathf.Round(vector.z));
        }

        public static Vector2 RoundVector(Vector2 vector)
        {
            return RoundVector((Vector3) vector);
        }
    }
}
