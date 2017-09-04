using System;
using DungeonTiles.Content.Attacks;
using UnityEngine;

namespace DungeonTiles.Ui.Player.States
{
    public class PlayerAttack : PlayerState
    {
        protected HeroPhaseState HeroPhaseState;

        /// <summary>
        /// The attack being used
        /// </summary>
        public Attack Attack { get; protected set; }

        protected Entity Entity;

        public PlayerAttack(PlayerFsm fsm, HeroPhaseState heroPhaseState, Attack attack) : base(fsm)
        {
            HeroPhaseState = heroPhaseState;
            Entity = fsm.Player.GetComponent<Entity>();
            Attack = attack;
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    // Object clicked
                    GameObject clickedObj = hit.collider.gameObject;
                    Entity target = clickedObj.GetComponent<Entity>();

                    if (target != null)
                    {
                        // An entity was clicked! Attack it.
                        Debug.Log("Attack: " + clickedObj.name);
                        Attack.DoAttack(target, Entity);

                        // Done attacking
                        Fsm.SetState(HeroPhaseState); // Return to pick action state
                    }
                }
            }
        }

        public override void End()
        {
            //
        }
    }
}
