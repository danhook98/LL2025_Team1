using UnityEngine;

namespace CannonGame.EventSystem
{
    [CreateAssetMenu(fileName = "Float Event",
                     menuName = Constants.MenuName + "Float Event",
                     order = Constants.MenuOrderPrimitive + 3)]
    public class FloatEvent : GameEvent<float> {}
}