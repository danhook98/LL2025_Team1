using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CannonGame
{
    public class WaveSpawner : MonoBehaviour
    {
        int screenSizeX;
        int screenSizeY;
        [SerializeField] float spawnPositionAddonInPixels;
        [SerializeField] EnemyProfile[] enemiesToSpawn;
        [SerializeField] float difficulty = 1;
        [SerializeField] float baseSpawnRate;
        [SerializeField] int baseSpawnAmount;
        int currentWave;
        [SerializeField] float timeBetweenWaves;
        List<GameObject> spawnableEnemiesThisRound;
        float spawnRate;
        int spawnAmount;
        [SerializeField]int waveAmountIncrease;
        bool spawning;
        float nextTimeToSpawn;
        int currentWaveSpawnCount;
        Transform enemyContainer;
        void Start()
        {
            enemyContainer = transform.GetChild(0);
            spawnableEnemiesThisRound = new List<GameObject>();
            screenSizeX = Screen.width;
			screenSizeY = Screen.height;
            StartWave();
		}

		private void Update()
		{
			if (!spawning)
            {
                return;
            }
            if(currentWaveSpawnCount < spawnAmount)
            {
				if (Time.time > nextTimeToSpawn)
				{
					SpawnEnemy(spawnableEnemiesThisRound[Random.Range(0, spawnableEnemiesThisRound.Count)]);
					nextTimeToSpawn = Time.time + 1 / spawnRate;
					currentWaveSpawnCount++;
				}
            }
            else
            {
                if(enemyContainer.childCount > 0)
                {
                    return;
                }
                spawning = false;
                Invoke("StartWave", timeBetweenWaves);
            }

		}

		void StartWave()
        {
            currentWave++;
            foreach (EnemyProfile EP in enemiesToSpawn)
            {
                if(EP.spawnStartWave <= currentWave && !spawnableEnemiesThisRound.Contains(EP.enemyToSpawn))
                {
                    spawnableEnemiesThisRound.Add(EP.enemyToSpawn);
                }
            }
            if(currentWave > 1)
            {
                //progressive difficulty ramp. probably quite bad and would need to be replaced by someone better with equastions
				float difficultyCalc = (-Mathf.Cos(currentWave) + currentWave) * difficulty;

				spawnRate = baseSpawnRate * difficultyCalc;
				spawnAmount = baseSpawnAmount + Mathf.FloorToInt(difficultyCalc * waveAmountIncrease);
            }
            else
            {
				spawnRate = baseSpawnRate;
				spawnAmount = baseSpawnAmount;
			}

            nextTimeToSpawn = 0;
            currentWaveSpawnCount = 0;

            spawning = true;
            Debug.Log("Wave : " + currentWave);
			Debug.Log("Spawn Amount : " + spawnAmount);
			Debug.Log("Spawn Rate : " + spawnRate);
			Debug.Log("Enemies : " + spawnableEnemiesThisRound);

		}

        void SpawnEnemy(GameObject enemy)
        {
            GameObject spawnedEnemy = Instantiate(enemy, ChooseSpawnPosition(),Quaternion.identity,enemyContainer);

            
        }

        //returns position outside of screen and scales dynamically with screen size
        Vector2 ChooseSpawnPosition()
        {
            float chosenX = Random.Range(-spawnPositionAddonInPixels, screenSizeX + spawnPositionAddonInPixels);
			float chosenY = Random.Range(-spawnPositionAddonInPixels, screenSizeY + spawnPositionAddonInPixels);
			while ((chosenX > 0 && chosenX < screenSizeX) && (chosenY > 0 && chosenY < screenSizeY))
            {
		        chosenX = Random.Range(-spawnPositionAddonInPixels, screenSizeX + spawnPositionAddonInPixels);
				chosenY = Random.Range(-spawnPositionAddonInPixels, screenSizeY + spawnPositionAddonInPixels);
			}
            Vector2 screenPosition = new Vector2(chosenX, chosenY);
			return Camera.main.ScreenToWorldPoint(screenPosition);
        }
    }
}
