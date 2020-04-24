using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "LevelSpawn", menuName = "Data/Enemy/LevelSpawn")]
    public sealed class LevelSpawnData : ScriptableObject
    {
        public bool UseRandomSpawn;
        public float Delay;
        // [Header("Not For Random")]
        public List<EnemyCount> WaveSettings;
        // [Header("Only For Random")] 
        // [Tooltip("Total enemy pack value")]
        // public int PackValue;

}
    }
