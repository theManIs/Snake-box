using System.Linq;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelPrefabs", menuName = "Data/Level/LevelPrefabs")]
    public class LevelPrefabs : ScriptableObject
    {
        [SerializeField] private LevelNamePrefabPair[] _levelNamePrefabPairs;

        public GameObject this[string name] => _levelNamePrefabPairs.Single(x => x.Name == name).Prefab;
    }

}