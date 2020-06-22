using System;
using UnityEngine;

namespace Snake_box
{
    [Serializable]
    public class SingleEnemySpawnData
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private float _spawnTiming;
        [SerializeField] private int _spawnPointId;

        public EnemyType EnemyType => _enemyType;
        public float SpawnTiming => _spawnTiming;
        public int SpawnPointId => _spawnPointId;

        public SingleEnemySpawnData(EnemyType enemyType, float spawnTiming, int spawnPointId)
        {
            _enemyType = enemyType;
            _spawnTiming = spawnTiming;
            _spawnPointId = spawnPointId;
        }
    } 
}
