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
                _poolsContainer = new GameObject("Object Pools");
            }

            ObjectPool<GameObject> pool = new(
                createFunc: () => CreateObject(prefab, position, rotation),
                actionOnGet: OnGetObject,
                actionOnRelease: OnReleaseObject,
                actionOnDestroy: OnDestroyObject);

            _pools.Add(prefab, pool);
        }

        private static GameObject CreateObject(GameObject obj, Vector3 position, Quaternion rotation)
        {
            return new GameObject();
        }

        private static void OnGetObject(GameObject obj)
        {

        }

        private static void OnReleaseObject(GameObject obj)
        {

        }

        private static void OnDestroyObject(GameObject obj)
        {

        }
    }
}
