using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Turns;
using DungeonTiles.Ui.States;
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
        protected PlayerMovement PlayerMovement;

        #endregion

        public void Start()
        {
            Game = Game.Instance;
            Player = PlayerObject.GetComponent<PlayerBehaviour>();

            InGameHud = new InGameHud(Game, Player);
            PlayerMovement = new PlayerMovement(Game, Player);

            InGameHud.Start();
            PlayerMovement.Start();

        }

        public void Update()
        {
            InGameHud.Update();
            PlayerMovement.Update();

        }
    }
}
