using System;
using DungeonTiles.Content.Attacks;
using UnityEngine;

namespace DungeonTiles.Ui.Player.States
{
    public class PlayerAttack : PlayerState
    {
        protected Entity Entity;

        public PlayerAttack(PlayerFsm fsm) : base(fsm)
        {
            Entity = fsm.Player.GetComponent<Entity>();
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
                        Attack.TestAttack.DoAttack(target, Entity);
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
