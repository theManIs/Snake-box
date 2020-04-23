using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level/LevelData")]
    public class LevelData : ScriptableObject
    {
        public SceneAsset Menu;
        public List<SceneAsset> Level;
    }
}
