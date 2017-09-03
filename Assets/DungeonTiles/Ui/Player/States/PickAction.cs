using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonTiles.Ui.Player.States
{
    public class PickAction : PlayerState
    {
        protected Canvas BottomCanvas;

        protected GameObject MoveCard;
        protected Button MoveCardBtn;

        protected Dictionary<AttackCardBehaviour, Button> AttackButtons = new Dictionary<AttackCardBehaviour, Button>();

        public PickAction(PlayerFsm fsm) : base(fsm)
        {
        }

        public override void Start()
        {
            // Get bottom canvas
            BottomCanvas = GameObject.Find("Bottom Canvas").GetComponent<Canvas>();
            BottomCanvas.enabled = true; // show canvas

            // Get movement card
            MoveCard = GameObject.Find("Move Card");
            MoveCardBtn = MoveCard.GetComponent<Button>();

            // Bind click handler for move card
            MoveCardBtn.onClick.RemoveAllListeners();
            MoveCardBtn.onClick.AddListener(() =>
            {
                Fsm.SetState(new PlayerMovement((PlayerFsm) Fsm));
            });

            UpdateAttackCards();
        }

        public override void End()
        {
            base.End();

            BottomCanvas.enabled = false;
        }

        public void UpdateAttackCards()
        {
            AttackButtons.Clear();

            // Get attack cards
            foreach (AttackCardBehaviour attackCardBehaviour in GameObject.FindObjectsOfType<AttackCardBehaviour>())
            {
                Button btn = attackCardBehaviour.gameObject.GetComponent<Button>();

                if (btn != null)
                {
                    AttackButtons.Add(attackCardBehaviour, btn);
                }
            }

            // Add click handlers
            foreach (KeyValuePair<AttackCardBehaviour, Button> attackCard in AttackButtons)
            {
                attackCard.Value.onClick.RemoveAllListeners();
                var card = attackCard; // To fix inconsistent behaviour when accessing 'attackCard' inside a closure
                attackCard.Value.onClick.AddListener(() =>
                {
                    Fsm.SetState(new PlayerAttack((PlayerFsm) Fsm, card.Key.GetAttack()));
                });
            }
        }
    }
}
