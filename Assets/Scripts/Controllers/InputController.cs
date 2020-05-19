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
            float inputAxis=0;             
            if (Input.GetKeyDown(KeyCode.A))
            {
                inputAxis = -1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                inputAxis = 1;
<<<<<<< HEAD
            }     
            
            _characterData.CharacterBehaviour.Move(inputAxis);
            
=======
            }           
            _characterData.CharacterBehaviour.Move(inputAxis);
            if (Input.GetKeyDown(AxisManager.SPACE))
            {               
                _characterData.CharacterBehaviour.AddBlock();/// добавление ячейки - хвост
            }
>>>>>>> parent of d17a243... Merge pull request #22 from Silvian-73/Code/Yuriy-K/ChangePCInput
            if (Input.GetKey(AxisManager.ESCAPE))
            {
                SceneManager.LoadScene(0);
            }           
        }

        #endregion
    }
}
