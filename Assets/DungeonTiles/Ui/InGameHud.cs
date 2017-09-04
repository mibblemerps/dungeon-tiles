using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Turns;
using DungeonTiles.Ui.Player;
using DungeonTiles.Ui.Player.States;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonTiles.Ui
{
    public class InGameHud : MonoBehaviour
    {
        protected Game Game;
        protected DungeonTiles.Player Player;
        protected PlayerFsm PlayerFsm;

        protected Text TurnStatusText;
        protected Text CharacterNameText;

        protected Turn Turn;

        public void Start()
        {
            Game = Game.Instance;
            Player = Game.LocalPlayer;
            PlayerFsm = Player.GetComponent<PlayerFsmBehaviour>().PlayerFsm;
            
            TurnStatusText = GameObject.Find("Text_TurnStatus").GetComponent<Text>();
            CharacterNameText = GameObject.Find("Text_CharacterName").GetComponent<Text>();
        }

        public void Update()
        {
            Turn = Game.TurnController.Turn;

            // todo: Make this update only on an as-needed basis.
            // Only update top left panel once every 15 frames
            if (Time.frameCount % 15 == 0)
                UpdateTopLeftPanel();
        }

        protected void UpdateTopLeftPanel()
        {
            // Set character name
            CharacterNameText.text = Player.name;

            // Set current turn status text. (Text_TurnStatus)
            if (Turn.CurrentPlayersTurn == Player)
            {
                switch (Turn.TurnPhase)
                {
                    case TurnPhase.Hero:
                        if (PlayerFsm.State is PlayerMovement)
                        {
                            PlayerMovement movementState = (PlayerMovement) PlayerFsm.State;
                            SetStatus("Moving: " + movementState.SquaresMoved + "/" + movementState.MaxMoves);
                        }
                        else if (PlayerFsm.State is PlayerAttack)
                        {
                            PlayerAttack attackState = (PlayerAttack) PlayerFsm.State;
                            SetStatus("Attacking With " + attackState.Attack.Name);
                        }
                        else
                        {
                            SetStatus("Your Turn");
                        }
                        break;

                    case TurnPhase.Exploration:
                        SetStatus("Your Exploration Phase");
                        break;

                    case TurnPhase.Monster:
                        SetStatus("Your Monster Phase");
                        break;
                }
            }
            else
            {
                TurnStatusText.text = Turn.CurrentPlayersTurn.name + "'s Turn";
            }
        }

        protected void SetStatus(string status)
        {
            TurnStatusText.text = status;
        }
    }
}
