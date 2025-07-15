using UnityEngine;
using UnityEngine.Events;

namespace CannonGame.EventSystem
{
    public class GameEventListener<T> : MonoBehaviour
    {
        [SerializeField] private GameEvent<T> eventToListen;
        [SerializeField] private UnityEvent<T> onEventInvoked;

        private void OnEnable() => eventToListen.Register(this);
        private void OnDisable() => eventToListen.Unregister(this);

        public void Listen(T value) => onEventInvoked.Invoke(value);
    }
}