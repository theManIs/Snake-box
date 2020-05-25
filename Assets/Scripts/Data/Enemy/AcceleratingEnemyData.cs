using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = "AcceleratingEnemyData", menuName = "Data/Enemy/AcceleratingEnemyData")]
    public class AcceleratingEnemyData: BaseEnemyData
    {
        [Tooltip("Максимальная скорость врага")]
        public float MaxSpeed;
        [Tooltip("Ускорение")]
        public float Accelerating;
    }
}
