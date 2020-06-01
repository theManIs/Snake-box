using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "BlockSnakeData", menuName = "Data/BlockSnake/BlockSnake")]
    public sealed class BlockSnakeData : ScriptableObject
    {
        public float HpBlock;//увиличения здоровья змейки при добовление блока
        public float SlowSnake;
        private BlockSnake _blockSnake;

        public BlockSnake Initialization()
        {
            var blocksnake = CustomResources.Load<BlockSnake>(AssetsPathGameObject.GameObjects[GameObjectType.BlockSnake]);
            _blockSnake =Instantiate(blocksnake);
            return _blockSnake;
        } 

        public float GetHp()
        {
            return HpBlock;
        }
    }
}
