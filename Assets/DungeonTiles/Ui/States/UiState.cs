using System;
using System.Collections.Generic;
using DungeonTiles.Turns;

namespace DungeonTiles.Ui.States
{
    public abstract class UiState
    {
        protected Game Game;
        protected PlayerBehaviour Player;

        public UiState(Game game, PlayerBehaviour player)
        {
            Game = game;
            Player = player;
        }

        public abstract void Start();

        public abstract void Update();
    }
}
