using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Turns;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonTiles.Ui
{
    public class InGameHud
    {
        protected Game Game;
        protected PlayerBehaviour Player;

        protected Text TurnStatusText;

        private Turn _turn;

        public InGameHud(Game game, PlayerBehaviour player)
        {
            Game = game;
            Player = player;

            TurnStatusText = GameObject.Find("Text_TurnStatus").GetComponent<Text>();
        }

        public void Start()
        {
            //
        }

        public void Update()
        {
            _turn = Game.TurnController.Turn;

            UpdateTopLeftPanel();
        }

        protected void UpdateTopLeftPanel()
        {
            // Set current turn status text. (Text_TurnStatus)
            if (_turn.CurrentPlayersTurn == Player)
            {
                switch (_turn.TurnPhase)
                {
                    case TurnPhase.Hero:
                        TurnStatusText.text = "Your Turn: Hero Phase";
                        break;
                    case TurnPhase.Exploration:
                        TurnStatusText.text = "Your Turn: Exploration Phase";
                        break;
                    case TurnPhase.Monster:
                        TurnStatusText.text = "Your Turn: Monster Phase";
                        break;
                }
            }
            else
            {
                TurnStatusText.text = _turn.CurrentPlayersTurn.name + "'s Turn";
            }
        }
    }
}
