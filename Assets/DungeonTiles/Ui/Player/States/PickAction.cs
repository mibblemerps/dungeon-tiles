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
        protected Canvas ActionsCanvas;

        protected Button MoveButton;
        protected Button AttackButton;
        protected Button UseItemButton;

        public PickAction(PlayerFsm fsm) : base(fsm)
        {
        }

        public override void Start()
        {
            ActionsCanvas = GameObject.Find("Actions Canvas").GetComponent<Canvas>();

            // Find buttons
            MoveButton = GameObject.Find("Action_Move").GetComponent<Button>();
            AttackButton = GameObject.Find("Action_Attack").GetComponent<Button>();
            UseItemButton = GameObject.Find("Action_UseItem").GetComponent<Button>();

            // Add click listeners
            MoveButton.onClick.RemoveAllListeners();
            MoveButton.onClick.AddListener(OnClickMove);

            AttackButton.onClick.RemoveAllListeners();
            AttackButton.onClick.AddListener(() =>
            {
                Fsm.SetState(new PlayerAttack((PlayerFsm) Fsm));
            });

            ActionsCanvas.enabled = true;
        }

        public override void End()
        {
            base.End();

            ActionsCanvas.enabled = false;
        }

        protected void OnClickMove()
        {
            Fsm.SetState(new PlayerMovement((PlayerFsm) Fsm));
        }
    }
}
