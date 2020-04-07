using UnityEngine;


namespace ExampleTemplate
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
            Vector2 inputAxis;
            inputAxis.x = Input.GetAxis("Horizontal");
            inputAxis.y = Input.GetAxis("Vertical");

            if (inputAxis.x != 0 || inputAxis.y != 0)
            {
                _characterData.CharacterBehaviour.Move(inputAxis);
            }            
        }

        #endregion
    }
}
