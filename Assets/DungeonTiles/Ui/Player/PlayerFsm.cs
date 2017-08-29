using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Events;
using DungeonTiles.Ui.Player.States;
using DungeonTiles.Util.Fsm;
using UnityEngine.Events;

namespace DungeonTiles.Ui.Player
{
    public class PlayerFsm : FiniteStateMachine
    {
        public Game Game;
        public DungeonTiles.Player Player;

        public PlayerFsm(Game game, DungeonTiles.Player player)
        {
            Game = game;
            Player = player;

            // Let the game know the players state changed.
            OnNewState.AddListener((state) =>
            {
                GameEvents.OnPlayerStateChange.Invoke(player, (PlayerState) state);
            });
        }
    }
}
