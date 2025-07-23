using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool; 

namespace CannonGame
{
    public class ObjectPoolManager : MonoBehaviour
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

        public static GameObject CreateObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject obj = Instantiate(prefab, position, rotation);

            obj.transform.SetPositionAndRotation(position, rotation);
            obj.transform.SetParent(_poolsContainer.transform, false);

            return obj;
        }

        private static void OnGetObject(GameObject obj)
        {
            // Enable the object.
            obj.SetActive(true);
        }

        private static void OnReleaseObject(GameObject obj)
        {
            // Disable the object. 
            obj.SetActive(false);
        }

        private static void OnDestroyObject(GameObject obj)
        {

        }
    }
}
