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
            _characterData.Initialization();           
        }

        #region IExecute

        public void Execute()
        {
            float inputAxis=0;             
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                inputAxis = -1;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                inputAxis = 1;
            }
            _characterData.CharacterBehaviour.Move(inputAxis);
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
