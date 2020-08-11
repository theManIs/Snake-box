using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "BonusCoinsData", menuName = "Data/Bonus/BonusCoinsData")]
    public class BonusCoinsData : BonusData
    {
        public int WorldCoins;
        public int LocalCoins;
    }
}