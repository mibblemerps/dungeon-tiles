using System;
using UnityEngine;

namespace DungeonTiles.Content.Attacks
{
    public class SimpleAttack : Attack
    {
        /// <summary>
        /// The dice roll bonus this attack gets.
        /// </summary>
        public int Attack { get; set; }
        /// <summary>
        /// The amount of damage inflicted if this attack is successful.
        /// </summary>
        public int Damage { get; set; }
        
        /// <param name="id">Unique ID</param>
        /// <param name="name">Human-readable name</param>
        /// <param name="attack">Dice roll bonus</param>
        /// <param name="damage">Damage inflicted if successful</param>
        public SimpleAttack(string id, string name, int attack, int damage) : base(id, name)
        {
        }

        public override void DoAttack(Entity target, Entity attacker)
        {
            if (GetDiceRoll() + Attack >= target.BaseArmour)
            {
                // Penetrates armour
                Debug.Log("Attack successful");

                target.Damage(Damage);
            }
            else
            {
                Debug.Log("Attack doesn't penetrate armour");
            }
        }
    }
}
