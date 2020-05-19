using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake_box
{
    public sealed class InputController : IExecute
    {
        private readonly CharacterData _characterData;

        public InputController()
        {
            _characterData = Data.Instance.Character;           
        }

        #region IExecute

        public void Execute()
        {
            Direction direction = Direction.None;          
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Direction.Left;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Direction.Right;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Direction.Up;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Direction.Down;
            }
            _characterData.CharacterBehaviour.Move(direction);
            if (Input.GetKeyDown(AxisManager.SPACE))
            {               
                _characterData.CharacterBehaviour.AddBlock();/// добавление ячейки - хвост
            }
            if (Input.GetKey(AxisManager.ESCAPE))
            {
                SceneManager.LoadScene(0);
            }           
        }

        #endregion
    }
}
