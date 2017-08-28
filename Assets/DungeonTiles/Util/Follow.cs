using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DungeonTiles.Util
{
    /// <summary>
    /// Smoothly follows a target.<br />
    /// This is especially useful for cameras.
    /// </summary>
    public class Follow : MonoBehaviour
    {
        public GameObject FollowTarget;

        [Tooltip("Offset to maintain away from the target. This is useful to prevent the camera moving into your player for example")]
        public Vector3 Offset = Vector3.zero;

        [Tooltip("The lower, the faster the smoothing action will be")]
        public float SmoothTime = 0.2f;
        
        public bool LockX = false;
        public bool LockY = false;
        public bool LockZ = false;

        private Vector3 _velocity = Vector3.zero;

        void Update()
        {
            if (FollowTarget == null) return;

            Vector3 newPos = Vector3.SmoothDamp(transform.position,
                FollowTarget.transform.position + Offset,
                ref _velocity, SmoothTime);

            transform.position = new Vector3(
                LockX ? transform.position.x : newPos.x,
                LockY ? transform.position.y : newPos.y,
                LockZ ? transform.position.z : newPos.z);
        }
    }
}
