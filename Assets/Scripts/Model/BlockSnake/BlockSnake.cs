using UnityEngine;


namespace ExampleTemplate
{
    public class BlockSnake : MonoBehaviour
    {
        private BlockSnakeData _blockSnakeData;

        private void Awake() 
        {  
            _blockSnakeData = Data.Instance.BlockSnake;           
        }        
    }
}
