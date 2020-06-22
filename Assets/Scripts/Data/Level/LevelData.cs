using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level/LevelData")]
    public sealed class LevelData : ScriptableObject
    {
        [SerializeField] private SingleLevelData[] SingleLevelDatas;

        private SingleLevelData GetSingleLevelData(LevelType levelType)
        {
            SingleLevelData result = SingleLevelDatas.SingleOrDefault(x => x.LevelType == levelType);
            if (result == null)
                throw new ArgumentException("Нет данных для уровня " + levelType);
            else
                return result;
        }

        public GameObject GetPrefab(LevelType levelType) => GetSingleLevelData(levelType).Prefab;
        public EnemySpawnList GetEnemySpawnList(LevelType levelType) => GetSingleLevelData(levelType).EnemySpawnList;
        public int GetInitialMoney(LevelType levelType) => GetSingleLevelData(levelType).InitialMoney;
    }
}

