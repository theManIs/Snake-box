namespace Snake_box
{
    public sealed class CharacterController : IExecute
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

        public void Execute()
        {
            _characterData.CharacterBehaviour.RegenerationArmor();
            _characterData.CharacterBehaviour.Collision();
            _characterData.CharacterBehaviour.ResetPosition();
        }

        #endregion
    }
}