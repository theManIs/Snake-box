using UnityEngine;
using System.Linq;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "AllSpawnListsData", menuName = "Data/Spawn/AllSpawnListsData")]
    public class AllSpawnListsData : ScriptableObject
    {
        [SerializeField] private LevelTypeEnemySpawnListPair[] _spawnLists;

        public EnemySpawnList GetEnemySpawnListByLevelType(LevelType levelType)
        {
            if (!HasSpawnListForLevel(levelType))
                throw new System.ArgumentException($"Для уровня {levelType} нет списка спауна");
            return _spawnLists.Single(x => x.LevelType == levelType).EnemySpawnList;
        }

        public bool HasSpawnListForLevel(LevelType levelType)
        {
            foreach (var pair in _spawnLists)
            {
                if (pair.LevelType == levelType && pair.EnemySpawnList != null)
                    return true;
            }
            return false;
        }
    }
}
