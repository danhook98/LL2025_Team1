using CannonGame.EventSystem;
using System.Collections.Generic;
using UnityEngine;

namespace CannonGame
{
    public class TurretManager : MonoBehaviour
    {
        [SerializeField] GameObject[] spawnableTurrets;
        List<GameObject> currentSpawnedTurrets;
        [SerializeField] Transform turretHolder;
        [SerializeField] IntEvent debugSpawnTurret;
        [SerializeField] float spawnDistance;
        [SerializeField] int maxTurretsPerRing;
        [SerializeField] float ringSeperation;
        [SerializeField] float orbitSpeed;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            currentSpawnedTurrets = new List<GameObject>();

		}

        // Update is called once per frame
        void Update()
        {
            turretHolder.Rotate(0, 0, orbitSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
				debugSpawnTurret.Invoke(0);
			}
        }

        public void SpawnTurret(int turretIndex)
        {
            GameObject spawnedTurret = Instantiate(spawnableTurrets[turretIndex], Vector2.zero, Quaternion.identity, turretHolder);
            currentSpawnedTurrets.Add(spawnedTurret);
            UpdateTurretPositions();
        }

        void UpdateTurretPositions()
        {
            int ringCount = (Mathf.CeilToInt(currentSpawnedTurrets.Count / maxTurretsPerRing)) + 1;
            Debug.Log("ring counnt :" + ringCount);
            for (int e = 0; e < ringCount; e++)
            {
                float angle = 360 / maxTurretsPerRing;
				for (int i = (maxTurretsPerRing) * e; i < currentSpawnedTurrets.Count; i++)
				{
					float angleInRadians = ((angle * i) + turretHolder.rotation.z) * Mathf.Deg2Rad;
					Vector3 pos = new(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0f);
					currentSpawnedTurrets[i].transform.position = pos * (spawnDistance + (e * ringSeperation));
				}
			}
        }
    }
}
