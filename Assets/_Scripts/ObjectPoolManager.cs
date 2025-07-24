using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool; 

namespace CannonGame
{
    public class ObjectPoolManager : MonoBehaviour
    {
        private static GameObject _poolsContainer; 

        private static Dictionary<GameObject, ObjectPool<GameObject>> _pools = new();
        private static Dictionary<GameObject, GameObject> _objPrefabMap = new();

        public static void CreatePool(GameObject prefab, int defaultCapacity = 10, int maxSize = 10)
        {
            if (!_poolsContainer)
            {
                _poolsContainer = new GameObject("Object Pool");
            }

            ObjectPool<GameObject> pool = new(
                createFunc: () => CreateObject(prefab),
                actionOnGet: OnGetObject,
                actionOnRelease: OnReleaseObject,
                actionOnDestroy: OnDestroyObject,
                collectionCheck: true,
                defaultCapacity: defaultCapacity,
                maxSize: maxSize
                );

            _pools.Add(prefab, pool);
        }

        private static GameObject CreateObject(GameObject prefab)
        {
            prefab.SetActive(false);

            GameObject obj = Instantiate(prefab);

            obj.transform.SetParent(_poolsContainer.transform, false);

            prefab.SetActive(true);

            return obj;
        }

        private static void OnGetObject(GameObject obj)
        {
            // Enable the object.
            //obj.SetActive(true);
            Debug.Log("Getting object!");
        }

        private static void OnReleaseObject(GameObject obj)
        {
            // Disable the object. 
            obj.SetActive(false);
            Debug.Log("Releasing object!");
        }

        private static void OnDestroyObject(GameObject obj)
        {
            Destroy(obj);
        }

        private static T SpawnObject<T>(GameObject obj, Vector3 position, Quaternion rotation) where T : Object
        {
            if (!_pools.ContainsKey(obj))
                CreatePool(obj);

            GameObject spawnedObject = _pools[obj].Get();

            if (!spawnedObject) return null; 
            
            if (!_objPrefabMap.ContainsKey(spawnedObject))
            {
                _objPrefabMap.Add(spawnedObject, obj);
            }

            spawnedObject.transform.SetPositionAndRotation(position, rotation);
            spawnedObject.SetActive(true);

            if (typeof(T) == typeof(GameObject))
            {
                return spawnedObject as T;
            }

            T component = spawnedObject.GetComponent<T>();

            if (!component) return null;

            return component;
        }

        public static T SpawnObject<T>(T objComponent, Vector2 position, Quaternion rotation) where T : Component
        {
            return SpawnObject<T>(objComponent.gameObject, position, rotation);
        }

        public static GameObject SpawnObject(GameObject obj, Vector2 position, Quaternion rotation)
        {
            return SpawnObject<GameObject>(obj, position, rotation);
        }

        public static void ReturnToPool(GameObject obj)
        {
            if (!_objPrefabMap.TryGetValue(obj, out GameObject prefab)) return; 

            if (_pools.TryGetValue(prefab, out ObjectPool<GameObject> pool))
            {
                pool.Release(obj);
                Debug.Log("Releasing object back to the pool.");
            }
        }
    }
}
