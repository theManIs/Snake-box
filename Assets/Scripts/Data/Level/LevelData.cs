using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level/LevelData")]
    public sealed class LevelData : ScriptableObject
    {
        public string Menu;
        public List<string> Level;
    }
}
