using UnityEngine;


namespace ExampleTemplate
{
    [CreateAssetMenu(fileName = "BlockSnakeData", menuName = "Data/BlockSnake/BlockSnake")]
    public sealed class BlockSnakeData : ScriptableObject
    {       
        private BlockSnake _blockSnake;

        public BlockSnake Initialization()
        {
            var blocksnake = CustomResources.Load<BlockSnake>(AssetsPathGameObject.GameObjects[GameObjectType.BlockSnake]);
            _blockSnake =Instantiate(blocksnake);
            return _blockSnake;
        }       
    }
}
