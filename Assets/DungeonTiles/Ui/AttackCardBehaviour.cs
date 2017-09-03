using DungeonTiles.Content.Attacks;
using UnityEngine;

namespace DungeonTiles.Ui
{
    public class AttackCardBehaviour : MonoBehaviour
    {
        public string AttackName = "test_attack";

        public Attack GetAttack()
        {
            return Attack.Attacks[AttackName];
        }
    }
}
