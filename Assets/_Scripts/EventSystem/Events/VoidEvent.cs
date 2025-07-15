using UnityEngine; 

namespace CannonGame.EventSystem
{
    [CreateAssetMenu(fileName = "Void Event",
                     menuName = Constants.MenuName + "Void Event",
                     order = Constants.MenuOrderVoid)]
    public class VoidEvent : GameEvent<Empty>
    {
        public void Invoke() => base.Invoke(new Empty());
    }

    public readonly struct Empty {}
}