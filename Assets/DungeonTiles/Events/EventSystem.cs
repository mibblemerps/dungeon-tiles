using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonTiles.Events
{
    public class EventSystem : MonoBehaviour
    {
        private IDictionary<string, UnityEvent> _events = new Dictionary<string, UnityEvent>();

        public bool LogEvents = false;

        protected UnityEvent GetUnityEvent(string eventName)
        {
            if (!_events.ContainsKey(eventName))
            {
                if (LogEvents) Debug.Log("[Event System] UnityEvent generated: " + eventName);

                _events[eventName] = new UnityEvent();
            }

            return _events[eventName];
        }

        public void Listen(string eventName, UnityAction action)
        {
            if (LogEvents) Debug.Log("[Event System] An action listened to: " + eventName);

            GetUnityEvent(eventName).AddListener(action);
        }

        public void Unlisten(string eventName, UnityAction action)
        {
            if (LogEvents) Debug.Log("[Event System] An action unlistened from: " + eventName);

            GetUnityEvent(eventName).RemoveListener(action);
        }

        public void RemoveAllListeners(string eventName)
        {
            if (LogEvents) Debug.Log("[Event System] Removed all listeners: " + eventName);

            GetUnityEvent(eventName).RemoveAllListeners();
        }

        public void Invoke(string eventName)
        {
            if (LogEvents) Debug.Log("[Event System] Event invoked: " + eventName);


            GetUnityEvent(eventName).Invoke();
        }
    }
}
