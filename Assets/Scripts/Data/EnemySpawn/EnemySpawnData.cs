using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "EnemySpawnData",menuName = "Data/Enemy/EnemySpawnData")]
    public class EnemySpawnData:ScriptableObject
    {
        public List<LevelSpawnData> LevelSpawnDatas;
    }
}
