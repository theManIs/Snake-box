using System;
using UnityEngine;

namespace Snake_box
{
    [Serializable]
    public class LevelTypeEnemySpawnListPair
    {
        [SerializeField] private LevelType _levelType;
        [SerializeField] private EnemySpawnList _enemySpawnList;

        public LevelType LevelType => _levelType;
        public EnemySpawnList EnemySpawnList => _enemySpawnList;
    } 
}
