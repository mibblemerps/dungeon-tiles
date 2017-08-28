using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Turns;
using DungeonTiles.Ui.Player.States;
using UnityEngine;
using UnityEngine.UI;

namespace DungeonTiles.Ui
{
    public class InGameUI : MonoBehaviour
    {
        public GameObject PlayerObject;
        protected PlayerBehaviour Player;
        protected Game Game;

        #region UiStates

        protected InGameHud InGameHud;

        #endregion

        public void Start()
        {
            Game = Game.Instance;
            Player = PlayerObject.GetComponent<PlayerBehaviour>();

            InGameHud = new InGameHud(Game, Player);

            InGameHud.Start();

        }

        public void Update()
        {
            InGameHud.Update();
        }
    }
}
