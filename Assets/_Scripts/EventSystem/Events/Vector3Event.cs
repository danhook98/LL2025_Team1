using UnityEngine;

namespace CannonGame.EventSystem
{
    [CreateAssetMenu(fileName = "Vector3 Event",
                     menuName = Constants.MenuName + "Vector3 Event",
                     order = Constants.MenuOrderUnityPrimitive + 1)]
    public class Vector3Event : GameEvent<Vector3> {}
}