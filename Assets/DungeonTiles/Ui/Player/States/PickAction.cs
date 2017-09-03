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

        public PickAction(PlayerFsm fsm) : base(fsm)
        {
        }

        public override void Start()
        {
            BottomCanvas = GameObject.Find("Bottom Canvas").GetComponent<Canvas>();

            MoveCard = GameObject.Find("Move Card");
            MoveCardBtn = MoveCard.GetComponent<Button>();

            BottomCanvas.enabled = true;

            // Bind click handler for move card
            MoveCardBtn.onClick.RemoveAllListeners();
            MoveCardBtn.onClick.AddListener(() =>
            {
                Fsm.SetState(new PlayerMovement((PlayerFsm) Fsm));
            });
        }

        public override void End()
        {
            base.End();

            BottomCanvas.enabled = false;
        }
    }
}
