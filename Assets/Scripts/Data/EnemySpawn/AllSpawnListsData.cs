using UnityEngine;
using System.Linq;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "AllSpawnListsData", menuName = "Data/Spawn/AllSpawnListsData")]
    public class AllSpawnListsData : ScriptableObject
    {
        [SerializeField] private LevelEnemySpawnListPair[] SpawnLists;

        public EnemySpawnList GetEnemySpawnListByLevelName(string name) => SpawnLists.Single(x => x.LevelName == name).EnemySpawnList;
    }
}
