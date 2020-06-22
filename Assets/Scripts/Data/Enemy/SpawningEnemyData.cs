using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "SpawningEnemyData", menuName = "Data/Enemy/SpawningEnemyData")]
    public class SpawningEnemyData: BaseEnemyData
    {
        public BaseEnemyData SpawnedAfterDaeth;
        public int Count;
    }
}
