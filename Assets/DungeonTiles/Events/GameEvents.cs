using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Turns;
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
        
        /// <summary>
        /// Called when an entity spawns.
        /// </summary>
        public static EntitySpawnedEvent OnEntitySpawned = new EntitySpawnedEvent();

        /// <summary>
        /// Called when an entity dies.
        /// </summary>
        public static EntityDiedEvent OnEntityDied = new EntityDiedEvent();

        /// <summary>
        /// Called when a new turn starts.
        /// </summary>
        public static NextTurnEvent OnNextTurn = new NextTurnEvent();

        /// <summary>
        /// Called when a player's turn phase has changed.
        /// </summary>
        public static NewTurnPhaseEvent OnNewTurnPhase = new NewTurnPhaseEvent();

        /// <summary>
        /// Called as a turn phase ends.
        /// </summary>
        public static TurnPhaseEndEvent OnTurnPhaseEnd = new TurnPhaseEndEvent();

        #region EventClasses

        public class PlayerStateChangeEvent : UnityEvent<Player, PlayerState> { }

        public class EntitySpawnedEvent : UnityEvent<Entity> { }

        public class EntityDiedEvent : UnityEvent<Entity> { }

        public class NextTurnEvent : UnityEvent<Player> { }

        public class NewTurnPhaseEvent : UnityEvent<Player, TurnPhase> { }

        public class TurnPhaseEndEvent : UnityEvent<Player, TurnPhase> { }

        #endregion
    }
}
