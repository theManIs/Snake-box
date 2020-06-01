using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "EnemySpawnList", menuName = "Data/Spawn/EnemySpawnList")]
    public class EnemySpawnList : ScriptableObject
    {
        [SerializeField] private SingleEnemySpawnData[] _enemies;

        public SingleEnemySpawnData[] Enemies => _enemies;
    } 
}
