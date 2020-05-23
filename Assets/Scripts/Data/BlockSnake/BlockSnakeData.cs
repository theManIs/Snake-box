using UnityEngine;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "BlockSnakeData", menuName = "Data/BlockSnake/BlockSnake")]
    public sealed class BlockSnakeData : ScriptableObject
    {
        [SerializeField] private float _hpBlock;//увиличения здоровья змейки при добовление блока
        private BlockSnake _blockSnake;

        public BlockSnake Initialization()
        {
            var blocksnake = CustomResources.Load<BlockSnake>(AssetsPathGameObject.GameObjects[GameObjectType.BlockSnake]);
            _blockSnake =Instantiate(blocksnake);
            return _blockSnake;
        }
        public float GetHp()
        {
            return _hpBlock;
        }
    }
}
