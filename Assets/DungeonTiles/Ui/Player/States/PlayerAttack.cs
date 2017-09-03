using System;
using DungeonTiles.Content.Attacks;
using UnityEngine;

namespace DungeonTiles.Ui.Player.States
{
    public class PlayerAttack : PlayerState
    {
        protected Entity Entity;
        protected Attack Attack;

        public PlayerAttack(PlayerFsm fsm, Attack attack) : base(fsm)
        {
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
                        Fsm.SetState(new PickAction((PlayerFsm) Fsm));
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
