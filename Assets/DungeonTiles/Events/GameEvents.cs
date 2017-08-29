using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Ui.Player.States;
using UnityEngine.Events;

namespace DungeonTiles.Events
{
    public static class GameEvents
    {
        /// <summary>
        /// Called when a player's state changes.
        /// </summary>
        public static PlayerStateChangeEvent OnPlayerStateChange = new PlayerStateChangeEvent();

        #region EventClasses

        public class PlayerStateChangeEvent : UnityEvent<Player, PlayerState> { }

        #endregion
    }
}
