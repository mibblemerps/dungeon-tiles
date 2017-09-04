using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DungeonTiles.Exploration.Generator
{
    public class TestGenerator : Generator
    {
        public GameObject GameTile;

        public override void GenerateTile(int x, int y)
        {
            GameObject newTile = Instantiate(GameTile);
            newTile.transform.position = new Vector3(x, newTile.transform.position.y, y);
        }
    }
}
