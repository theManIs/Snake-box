using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "BlockSnakeData", menuName = "Data/BlockSnake/BlockSnake")]
    public sealed class BlockSnakeData : ScriptableObject
    {
        public float HpBlock;//увиличения здоровья змейки при добовление блока
        public float SlowSnake;
        public int Coins;
        public Transform Prefab;        
    }
}
