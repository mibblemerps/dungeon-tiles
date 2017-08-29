using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Util.Fsm;

namespace DungeonTiles.Ui.Player
{
    public class PlayerFsm : FiniteStateMachine
    {
        public Game Game;
        public PlayerBehaviour Player;

        public PlayerFsm(Game game, PlayerBehaviour player)
        {
            Game = game;
            Player = player;
        }
    }
}
