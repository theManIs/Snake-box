using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake_box
{
    public sealed class InputController : IExecute
    {
        #region Private Data

        private KeyCode _left = KeyCode.A;
        private KeyCode _right = KeyCode.D;
        private KeyCode _up = KeyCode.W;
        private KeyCode _down = KeyCode.S;        

        #endregion
        

        #region IExecute

        public void Execute()
        {
            Direction direction = Direction.None;          
            if (Input.GetKeyDown(_left))
            {
                direction = Direction.Left;
            }
            if (Input.GetKeyDown(_right))
            {
                direction = Direction.Right;
            }
            if (Input.GetKeyDown(_up))
            {
                direction = Direction.Up;
            }
            if (Input.GetKeyDown(_down))
            {
                direction = Direction.Down;
            }
            Services.Instance.LevelService.CharacterBehaviour.InputMove(direction);
            Services.Instance.LevelService.CharacterBehaviour.TeleportIfOutOfBorder();
            if (Input.GetKey(AxisManager.ESCAPE))
            {
                SceneManager.LoadScene(0);
            }                   
        }

        #endregion
    }
}
