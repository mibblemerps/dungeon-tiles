using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Events;
using DungeonTiles.Turns;
using DungeonTiles.Ui.Player.States;
using DungeonTiles.Util.Fsm;
using UnityEngine.Events;

namespace DungeonTiles.Ui.Player
{
    public class PlayerFsm : FiniteStateMachine
    {
        public Game Game;
        public DungeonTiles.Player Player;

        protected PlayerState IdlePlayerState;

        public PlayerFsm(Game game, DungeonTiles.Player player)
        {
            Game = game;
            Player = player;

            IdlePlayerState = new PlayerState(this);

            // Let the game know the players state changed.
            OnNewState.AddListener((state) =>
            {
                GameEvents.OnPlayerStateChange.Invoke(player, (PlayerState) state);
            });

            GameEvents.OnNewTurnPhase.AddListener((newPlayer, turnPhase) =>
            {
                // Check if this is the player we're managing.
                if (newPlayer != player)
                {
                    SetState(IdlePlayerState);
                    return;
                }
                
                if (turnPhase == TurnPhase.Hero)
                    SetState(new HeroPhaseState(this));
                else
                    SetState(IdlePlayerState);
            });
        }
    }
}
