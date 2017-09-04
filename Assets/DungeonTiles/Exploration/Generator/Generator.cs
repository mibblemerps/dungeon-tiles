using UnityEngine;

namespace DungeonTiles.Exploration.Generator
{
    public abstract class Generator : MonoBehaviour
    {
        public Generator()
        {
        }

        public abstract void GenerateTile(int x, int y);
    }
}
