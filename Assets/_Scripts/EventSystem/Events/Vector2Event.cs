using UnityEngine;

namespace CannonGame.EventSystem
{
    [CreateAssetMenu(fileName = "Vector2 Event",
                     menuName = Constants.MenuName + "Vector2 Event",
                     order = Constants.MenuOrderUnityPrimitive + 0)]
    public class Vector2Event : GameEvent<Vector2> {}
}