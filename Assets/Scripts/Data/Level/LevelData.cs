using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level/LevelData")]
    public sealed class LevelData : ScriptableObject
    {
        public SceneAsset Menu;
        public List<SceneAsset> Level;
    }
}

