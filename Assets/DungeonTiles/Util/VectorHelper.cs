using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DungeonTiles.Util
{
    public static class VectorHelper
    {
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
