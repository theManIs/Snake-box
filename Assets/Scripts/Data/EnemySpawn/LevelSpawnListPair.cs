using System;
using UnityEngine;

namespace Snake_box
{
    [Serializable]
    public class LevelEnemySpawnListPair
    {
        [SerializeField] private string _levelName;
        [SerializeField] private EnemySpawnList _enemySpawnList;

        public string LevelName => _levelName;
        public EnemySpawnList EnemySpawnList => _enemySpawnList;
    } 
}
