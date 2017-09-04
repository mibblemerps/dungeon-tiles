using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonTiles.Grid
{
    /// <summary>
    /// Keeps track of where everything is on the grid.
    /// </summary>
    public class GridController : MonoBehaviour
    {
        public List<GridAware> GridAwareObjects = new List<GridAware>();

        /// <summary>
        /// Get the list of game objects at a position.
        /// </summary>
        /// <param name="position">Position on the grid</param>
        /// <returns>List of relevant game objects</returns>
        public List<GameObject> GetObjectsAt(Vector2 position)
        {
            var found = new List<GameObject>();

            foreach (GridAware gridAware in GridAwareObjects)
            {
                // Skip disabled GridAware's
                if (!gridAware.enabled)
                    continue;

                Vector3 objPosition = gridAware.GetGridAwarePosition();
                Vector2 gridPosition = new Vector2(objPosition.x, objPosition.z);

                if (position == gridPosition)
                    found.Add(gridAware.gameObject);
            }

            return found;
        }

        /// <summary>
        /// Get the list of game objects at a position which have a particular game object.
        /// Note this list will contain the game objects, not the components requested.
        /// </summary>
        /// <typeparam name="T">Component the game objects must have</typeparam>
        /// <param name="position">Position on the grid</param>
        /// <returns>List of relevant game objects</returns>
        public List<GameObject> GetComponentsAt<T>(Vector2 position)
        {
            // Get all game objects at this position so we can check them all
            List<GameObject> gameObjects = GetObjectsAt(position);

            var found = new List<GameObject>();

            // Loop through all game objects and check if they have the requested component
            foreach (GameObject gameObj in gameObjects)
            {
                if (gameObj.GetComponent<T>() != null)
                {
                    found.Add(gameObj);
                }
            }

            return found;
        }

        /// <summary>
        /// Checks if a particular game object can move to a particular position.
        /// </summary>
        /// <param name="position">Position wanting to move to</param>
        /// <param name="obj">Game object wanting to move there</param>
        /// <returns>Can move?</returns>
        public bool CanMoveTo(Vector2 position, GameObject obj)
        {
            // Get objects at the target pos
            List<GameObject> existingObjects = GetObjectsAt(position);

            // There is nothing here (not even a floor). You cannot move here.
            if (existingObjects.Count == 0)
                return false;

            // Loop through all objects at this position and check if we can collide with it
            foreach (GameObject existingObject in existingObjects)
            {
                GridAware gridAware = existingObject.GetComponent<GridAware>();
                if (!gridAware.CanOtherObjectMoveHere(obj))
                    return false;
            }

            return true;
        }
    }
}
