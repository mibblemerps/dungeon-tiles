using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Turns;
using DungeonTiles.Util;
using DungeonTiles.Util.Fsm;
using UnityEngine;

namespace DungeonTiles.Ui.Player.States
{
    public class PlayerMovement : PlayerState
    {
        protected HeroPhaseState HeroPhaseState;

        public int MaxMoves = 8;

        public int SquaresMoved;

        protected SmoothMovement GridMovement;

        public PlayerMovement(PlayerFsm fsm, HeroPhaseState heroPhaseState) : base(fsm)
        {
            HeroPhaseState = heroPhaseState;
        }

        public override void Start()
        {
            GridMovement = Player.gameObject.GetComponent<SmoothMovement>();
        }

        public override void Update()
        {
            // Work out movement vector
            // First we calculate the angle the camera is at, so we can apply it to the movement vector so we move in the direction the player
            // would expect based on their camera angle.
            Quaternion eulerAngles = Quaternion.Euler(
                0, // This is 0 to prevent the character moving into the ground/air if the camera is rotated on the X-axis.
                Mathf.Round(Camera.main.transform.eulerAngles.y / 90) * 90, // These get rounded to the nearest 90 to ensure we stick the grid.
                Mathf.Round(Camera.main.transform.eulerAngles.z / 90) * 90);

            Vector3 movementVector = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.W)) movementVector = movementVector + eulerAngles * Vector3.forward;
            else if (Input.GetKeyDown(KeyCode.S)) movementVector = movementVector + eulerAngles * Vector3.back;
            else if (Input.GetKeyDown(KeyCode.A)) movementVector = movementVector + eulerAngles * Vector3.left;
            else if (Input.GetKeyDown(KeyCode.D)) movementVector = movementVector + eulerAngles * Vector3.right;

            if (movementVector != Vector3.zero)
            {
                Vector3 targetPos = GridMovement.TargetPosition + movementVector;

                if (Game.GridController.CanMoveTo(new Vector2(targetPos.x, targetPos.z), Player.gameObject))
                {
                    GridMovement.TargetPosition = targetPos;
                    SquaresMoved++;
                }
            }

            // Max moves
            if (SquaresMoved >= MaxMoves)
            {
                Fsm.SetState(HeroPhaseState); // Return to pick action state
            }
        }
    }
}
