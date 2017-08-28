using UnityEngine;
using System.Collections;

namespace DungeonTiles.Grid
{
    /// <summary>
    /// Marks this GameObject as something that is aware of the dungeon tiles grid.
    /// It'll then be findable through the GridController.
    /// </summary>
    public class GridAware : MonoBehaviour
    {
        public bool IsCollidable = false;

        protected GridController GridController;

        // Use this for initialization
        void Start()
        {
            GridController = Game.Instance.GridController;

            GridController.GridAwareObjects.Add(this);
        }

        /// <summary>
        /// Get the current grid aware position of the player.<br />
        /// <br />
        /// Currently this just rounds the transform's position to the nearest int.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetGridAwarePosition()
        {
            return new Vector3(
                Mathf.Round(gameObject.transform.position.x),
                Mathf.Round(gameObject.transform.position.y),
                Mathf.Round(gameObject.transform.position.z));
        }

        /// <summary>
        /// Can the specified object move here?<br />
        /// By default this depends on whether this object is marked as collidable.
        /// </summary>
        /// <param name="otherObject">Other object that wants to move here</param>
        /// <returns></returns>
        public bool CanOtherObjectMoveHere(GameObject otherObject)
        {
            return !IsCollidable;
        }
    }
}
