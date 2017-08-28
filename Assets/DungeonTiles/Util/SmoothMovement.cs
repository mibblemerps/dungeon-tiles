using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DungeonTiles.Util
{
    public class SmoothMovement : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private float _progress;

        public float MoveSpeed = 2.5f;

        public Vector3 TargetPosition
        {
            get { return _targetPosition; }
            set
            {
                // Set new target, start pos and reset lerp progress.
                _progress = 0;
                _startPosition = gameObject.transform.position;
                _targetPosition = value;
            }
        }

        void Start()
        {
            TargetPosition = gameObject.transform.position;
        }

        void Update()
        {
            if (gameObject.transform.position != TargetPosition && _progress <= 1f)
            {
                _progress = _progress + Time.deltaTime * MoveSpeed;
                transform.position = Vector3.Lerp(_startPosition, _targetPosition, _progress);
            }
        }
    }
}
