namespace Snake_box
{
    public sealed class CharacterController : IExecute, ICleanUp
    {
        #region Fields       

        private readonly CharacterData _characterData;

        #endregion


        #region Methods

        public CharacterController()
        {
            _characterData = Data.Instance.Character;
            _characterData.Initialization();
        }

        public void Clean()
        {
            GameController.Destroy(_characterData._characterBehaviour.gameObject);
        }

        public void Execute()
        {            
            _characterData._characterBehaviour.RegenerationArmor();
            _characterData._characterBehaviour.Collision();
            _characterData._characterBehaviour.ResetPosition();
        }

        #endregion
    }
}