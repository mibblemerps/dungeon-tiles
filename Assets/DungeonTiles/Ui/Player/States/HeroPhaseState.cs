using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Turns;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonTiles.Ui.Player.States
{
    public class HeroPhaseState : PlayerState
    {
        protected Canvas BottomCanvas;

        protected GameObject MoveCard;
        protected Button MoveCardBtn;

        protected Dictionary<AttackCardBehaviour, Button> AttackButtons = new Dictionary<AttackCardBehaviour, Button>();

        public int Moves;
        public int Attacks;

        public HeroPhaseState(PlayerFsm fsm) : base(fsm)
        {
        }

        public override void Start()
        {
            if (Moves + Attacks >= 2)
            {
                // Finished hero phase
                Game.TurnController.CurrentPhase = TurnPhase.Exploration;
                return;
            }

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
                Moves++;
                Fsm.SetState(new PlayerMovement((PlayerFsm) Fsm, this));
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

                    // Only allow using attack if an attack hasn't been used yet.
                    btn.interactable = Attacks <= 0;
                }
            }

            // Add click handlers
            foreach (KeyValuePair<AttackCardBehaviour, Button> attackCard in AttackButtons)
            {
                attackCard.Value.onClick.RemoveAllListeners();
                var card = attackCard; // To fix inconsistent behaviour when accessing 'attackCard' inside a closure
                attackCard.Value.onClick.AddListener(() =>
                {
                    Attacks++;
                    Fsm.SetState(new PlayerAttack((PlayerFsm) Fsm, this, card.Key.GetAttack()));
                });
            }
        }
    }
}
