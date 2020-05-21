using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "SpikedEnemyData", menuName = "Data/Enemy/SpikedEnemyData")]
    public class SpikedEnemyData:BaseEnemyData
    {
        [Range(0, 100)] public float SpikeTreshold;
    }
}
