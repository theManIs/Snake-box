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
            float inputAxis;
            inputAxis = Input.GetAxisRaw(AxisManager.HORIZONTAL);
            _characterData.CharacterBehaviour.Move(inputAxis);

            if (Input.GetKeyDown(AxisManager.SPACE))
            {
                _characterData.CharacterBehaviour.AddBlock();
            }
        }

        #endregion
    }
}
