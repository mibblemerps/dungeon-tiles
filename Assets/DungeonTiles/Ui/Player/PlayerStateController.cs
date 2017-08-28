using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Ui.Player.States;
using UnityEngine;

namespace DungeonTiles.Ui.Player
{
    public class PlayerStateController : MonoBehaviour
    {
        private PlayerState _playerState;

        public PlayerState PlayerState
        {
            get { return _playerState; }
            set { SetState(value); }
        }

        public Game Game;
        public PlayerBehaviour Player;

        public void Start()
        {
            Game = Game.Instance;
            Player = GetComponent<PlayerBehaviour>();
            
            // Set initial state
            PlayerState = new PlayerMovement(this);
        }

        public void Update()
        {
            PlayerState.Update();
        }

        public void SetState(PlayerState state)
        {
            Debug.Log("New player state: " + state.ToString());

            if (_playerState != null)
            {
                // Call End method on old state
                _playerState.End();

                // Clear reference the state before the old one (so we don't end up with a massive chain of old states that can never be gc'd)
                _playerState.PreviousState = null;

                // Set the previous state of the new state to the old state
                state.PreviousState = _playerState;
            }

            // Set the new state and call it's start method so it can init
            _playerState = state;
            _playerState.Start();
        }
    }
}
