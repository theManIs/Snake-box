using UnityEngine;
using System.Linq;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "AllSpawnListsData", menuName = "Data/Spawn/AllSpawnListsData")]
    public class AllSpawnListsData : ScriptableObject
    {
        [SerializeField] private LevelEnemySpawnListPair[] _spawnLists;

        public EnemySpawnList GetEnemySpawnListByLevelName(string name)
        {
            if (!HasSpawnListForLevel(name))
                throw new System.ArgumentException($"Для уровня {name} нет списка спауна");
            return _spawnLists.Single(x => x.LevelName == name).EnemySpawnList;
        }

        public bool HasSpawnListForLevel(string levelName)
        {
            foreach (var pair in _spawnLists)
            {
                if (pair.LevelName == levelName && pair.EnemySpawnList != null)
                    return true;
            }
            return false;
        }
    }
}
