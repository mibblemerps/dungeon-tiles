using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Util.Fsm;

namespace DungeonTiles.Ui.Player.States
{
    public class PlayerState : State
    {
        protected Game Game;
        protected PlayerBehaviour Player;

        public PlayerState(PlayerFsm fsm) : base(fsm)
        {
            Game = fsm.Game;
            Player = fsm.Player;
        }
    }
}
