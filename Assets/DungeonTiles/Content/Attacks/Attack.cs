using UnityEngine;

namespace DungeonTiles.Content.Attacks
{
    public abstract class Attack
    {
        /// <summary>
        /// Unique ID for this attack.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Human-readable name for this attack.
        /// </summary>
        public string Name { get; private set; }

        protected Attack(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Where the attack should calculate what it should do to the target entity.
        /// </summary>
        /// <param name="target">Target entity to be attacked</param>
        /// <param name="attacker">Entity attacking them</param>
        public abstract void DoAttack(Entity target, Entity attacker);

        /// <summary>
        /// Get a random 1-20 dice roll.
        /// </summary>
        /// <returns>Random integer between 1-20</returns>
        protected int GetDiceRoll()
        {
            // todo: add hooks to allow influencing dice roll
            return Random.Range(1, 20);
        }

        #region Attacks

        public static SimpleAttack TestAttack = new SimpleAttack("test_attack", "Test Attack", 5, 1);

        #endregion
    }
}
