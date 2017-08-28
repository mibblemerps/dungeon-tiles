using System;
using System.Collections.Generic;
using DungeonTiles.Turns;

namespace DungeonTiles.Ui.Player.States
{
    public abstract class PlayerState
    {
        protected PlayerStateController StateController;
        protected Game Game;
        protected PlayerBehaviour Player;
        
        public PlayerState PreviousState;

        protected PlayerState(PlayerStateController stateController)
        {
            StateController = stateController;

            Game = StateController.Game;
            Player = StateController.Player;
        }

        public abstract void Start();

        public abstract void Update();

        public virtual void End() { }

        protected void SetState(PlayerState newState)
        {
            StateController.PlayerState = newState;
        }

        public void Exit()
        {
            StateController.PlayerState = PreviousState;
        }
    }
}
