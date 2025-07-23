using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool; 

namespace CannonGame
{
    public static class ObjectPoolManager
    {
        private static GameObject _poolsContainer; 

        private static Dictionary<GameObject, ObjectPool<GameObject>> _pools = new();

        public static void CreatePool(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            if (!_poolsContainer)
            {
                _poolsContainer= new GameObject("Object Pools");
            }
        }

        private static void CreateObject()
        {

        }

        private static void OnGetObject()
        {

        }

        private static void OnReleaseObject()
        {

        }

        private static void OnDestroyObject()
        {

        }
    }
}
