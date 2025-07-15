using System.Collections.Generic;
using UnityEngine;

namespace CannonGame.EventSystem
{
    public class GameEvent<T> : ScriptableObject
    {
        [SerializeField] private string description;

        private readonly List<GameEventListener<T>> _listeners = new();

        public void Register(GameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener)) _listeners.Add(listener);
        }

        public void Unregister(GameEventListener<T> listener)
        {
            if (_listeners.Contains(listener)) _listeners.Remove(listener);
        }

        public void Invoke(T value)
        {
            // Iterate through the listeners in reverse order, that way if any events unregister it won't mess up the 
            // rest of the invokes. 
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].Listen(value);
            }
        }
    }
}