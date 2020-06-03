using System;
using System.Linq;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelPrefabs", menuName = "Data/Level/LevelPrefabs")]
    public class LevelPrefabs : ScriptableObject
    {
        [SerializeField] private LevelTypePrefabPair[] _levelTypePrefabPairs;

        public GameObject this[LevelType levelType]
        {
            get
            {
                if (!LevelExists(levelType))
                    throw new ArgumentException($"Уровня {levelType} не существует");
                return _levelTypePrefabPairs.Single(x => x.LevelType == levelType).Prefab;
            }
        }

        public bool LevelExists(LevelType levelType)
        {
            foreach (var pair in _levelTypePrefabPairs)
            {
                if (pair.LevelType == levelType)
                    return true;
            }
            return false;
        }
    }

}