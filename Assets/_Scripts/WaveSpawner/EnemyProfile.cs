using UnityEngine;

namespace CannonGame
{
    [CreateAssetMenu(fileName = "EnemyProfile", menuName = "CannonGame/EnemyProfile")]
    public class EnemyProfile : ScriptableObject
    {
        public GameObject enemyToSpawn;
        public int spawnStartWave;
    }
}
