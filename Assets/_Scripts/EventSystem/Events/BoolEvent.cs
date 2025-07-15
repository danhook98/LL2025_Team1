using UnityEngine; 

namespace CannonGame.EventSystem
{
    [CreateAssetMenu(fileName = "Bool Event",
                     menuName = Constants.MenuName + "Bool Event",
                     order = Constants.MenuOrderPrimitive + 0)]
    public class BoolEvent : GameEvent<bool> {}
}