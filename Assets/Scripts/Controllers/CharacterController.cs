namespace Snake_box
{
    public sealed class CharacterController : IExecute
    {
        private readonly CharacterData _characterData;

        public CharacterController()
        {
            _characterData = Data.Instance.Character;
            _characterData.Initialization();
        }
        public void Execute()
        {           
            _characterData.RegenerationArmor();
        }       
    }
}