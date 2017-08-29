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
        
        /// <summary>
        /// Called when an entity spawns.
        /// </summary>
        public static EntitySpawnedEvent OnEntitySpawned = new EntitySpawnedEvent();

        /// <summary>
        /// Called when an entity dies.
        /// </summary>
        public static EntityDiedEvent OnEntityDied = new EntityDiedEvent();

        #region EventClasses

        public class PlayerStateChangeEvent : UnityEvent<Player, PlayerState> { }

        public class EntitySpawnedEvent : UnityEvent<Entity> { }

        public class EntityDiedEvent : UnityEvent<Entity> { }

        #endregion
    }
}
