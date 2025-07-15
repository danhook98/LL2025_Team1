using UnityEngine;

namespace CannonGame.EventSystem
{
    [CreateAssetMenu(fileName = "Int Event",
                     menuName = Constants.MenuName + "Int Event",
                     order = Constants.MenuOrderPrimitive + 1)]
    public class IntEvent : GameEvent<int> {}
}