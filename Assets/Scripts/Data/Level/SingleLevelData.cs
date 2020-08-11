using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    [Serializable]
    public class SingleLevelData
    {
        public LevelType LevelType;
        public GameObject Prefab;
        public EnemySpawnList EnemySpawnList;
        public int InitialMoney;
    }
}