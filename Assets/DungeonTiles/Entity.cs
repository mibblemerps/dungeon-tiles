using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonTiles.Events;
using UnityEngine;

namespace DungeonTiles
{
    /// <summary>
    /// An entity is something such as a player or monster.<br />
    /// It has stats such as health.
    /// </summary>
    public class Entity : MonoBehaviour
    {
        private int _health;

        /// <summary>
        /// Base armour value before any modifiers.
        /// </summary>
        public int BaseArmour = 14;
        /// <summary>
        /// Base health value not including any damage taken or modifiers.
        /// </summary>
        public int BaseHealth = 6;
        /// <summary>
        /// Base speed before any modifiers.
        /// </summary>
        public int BaseSpeed = 6;
        /// <summary>
        /// How much health is restored upon using a surge.
        /// </summary>
        public int SurgeValue = 3;

        /// <summary>
        /// Is this entity alive?
        /// </summary>
        public bool IsAlive { get { return _health > 0; } }
        /// <summary>
        /// Entities current health.
        /// </summary>
        public int CurrentHealth
        {
            get { return _health; }
            set { SetHealth(value); }
        }

        public void Start()
        {
            _health = BaseHealth;
        }

        /// <summary>
        /// Set the health of this entity.
        /// You can also set <i>CurrentHealth</i> directly.
        /// </summary>
        /// <param name="health">New health</param>
        public void SetHealth(int health)
        {
            _health = health;

            if (health <= 0)
            {
                // Kill entity
                Kill();
            }
        }

        /// <summary>
        /// Damage the entity directly with the specified amount of damage.
        /// </summary>
        /// <param name="damage">Damage points</param>
        public void Damage(int damage)
        {
            CurrentHealth = CurrentHealth - damage;
        }

        /// <summary>
        /// Kill this entity.
        /// </summary>
        public void Kill()
        {
            _health = 0;

            GameEvents.OnEntityDied.Invoke(this);
        }
    }
}
