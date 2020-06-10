using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "BonusSpeedData", menuName = "Data/Bonus/BonusSpeedData")]
    public class BonusSpeedData : BonusData
    {
        public int Speed;
        public int TimeEffect;
    }
}
