using UnityEngine;

namespace CannonGame.EventSystem
{
    public class Constants
    {
        private const string _gameName = "CannonGame";

        // Menu strings.
        internal const string MenuName = _gameName + "/Events (base)/";
        internal const string MenuNameCustom = _gameName + "/Events (custom)/";

        // Menu ordering.
        private const int _menuOrderBase = 0;

        internal const int MenuOrderVoid = _menuOrderBase;
        internal const int MenuOrderPrimitive = _menuOrderBase + 100; 
        internal const int MenuOrderUnityPrimitive = _menuOrderBase + 200; 
    }
}
