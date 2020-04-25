using UnityEngine;


namespace Snake_box
{
    public sealed class BlockSnake : MonoBehaviour
    {
        #region Fields

        private BlockSnakeData _blockSnakeData;

        #endregion


        #region Unity Method

        private void Awake() 
        {             
            _blockSnakeData = Data.Instance.BlockSnake;           
        }

        #endregion
    }
}
