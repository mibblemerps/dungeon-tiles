using UnityEngine;

namespace DungeonTiles.Events
{
    public class EventLogger : MonoBehaviour
    {
        public void Start()
        {
            GameEvents.OnPlayerStateChange.AddListener((playerBehaviour, playerState) =>
            {
                Log("OnPlayerStateChange: " + playerBehaviour.gameObject.name + ", " + playerState.ToString());
            });
        }

        protected void Log(string msg, int level = 1)
        {
            // Don't log if disabled
            if (!enabled) return;

            Debug.Log("[Event] " + msg);
        }
    }
}
