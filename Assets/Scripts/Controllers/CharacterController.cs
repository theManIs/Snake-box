using UnityEngine;


namespace Snake_box
{
    public sealed class CharacterController : IExecute, ICleanUp, IInitialization    
    {
        #region Fields  
        
        private CharacterBehaviour _characterBehaviour;

        #endregion


        #region Methods        

        public void Initialization()
        {
            Services.Instance.LevelService.IsSnakeAlive = true;
            var characterBehaviour = CustomResources.Load<CharacterBehaviour>
                (AssetsPathGameObject.GameObjects[GameObjectType.Character]);
            _characterBehaviour = Object.Instantiate(characterBehaviour);
            Services.Instance.LevelService.CharacterBehaviour = _characterBehaviour;
        }

        public void Clean()
        {
            GameController.Destroy(_characterBehaviour.gameObject);
        }

        public void Execute()
        {            
            _characterData._characterBehaviour.RegenerationArmor();
            _characterData._characterBehaviour.Collision();
            _characterData._characterBehaviour.ResetPosition();
            _characterData._characterBehaviour.DecreaseRamCooldown();
        }

        #endregion
    }
}