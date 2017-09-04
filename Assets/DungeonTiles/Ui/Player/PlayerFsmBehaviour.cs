using UnityEngine;

namespace DungeonTiles.Ui.Player
{
    public class PlayerFsmBehaviour : MonoBehaviour
    {
        public PlayerFsm PlayerFsm;

        public void OnEnable()
        {
            DungeonTiles.Player player = GetComponent<DungeonTiles.Player>();
            Game game = Game.Instance;

            PlayerFsm = new PlayerFsm(game, player);
        }

        public void Start()
        {
            //PlayerFsm.SetState(new HeroPhaseState(PlayerFsm));
        }

        public void Update()
        {
            // Update the player state machine
            PlayerFsm.Update();
        }
    }
}
