using System;
using System.Linq;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelPrefabs", menuName = "Data/Level/LevelPrefabs")]
    public class LevelPrefabs : ScriptableObject
    {
        [SerializeField] private LevelNamePrefabPair[] _levelNamePrefabPairs;

        public GameObject this[string name]
        {
            get
            {
                if (!LevelExists(name))
                    throw new ArgumentException($"Уровня с именем {name} не существует");
                return _levelNamePrefabPairs.Single(x => x.Name == name).Prefab;
            }
        }

        public bool LevelExists(string name)
        {
            foreach (var pair in _levelNamePrefabPairs)
            {
                if (pair.Name == name)
                    return true;
            }
            return false;
        }
    }

}