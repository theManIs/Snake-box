using UnityEngine;


namespace ExampleTemplate
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields
        
        private Controllers _controllers;
        
        #endregion
        

        #region UnityMethods
        
        private void Start()
        {
            _controllers = new Controllers();
            Initialization();
            //ScreenInterface.GetInstance().Execute(ScreenType.MainMenu);
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute();
            }
        }

        #endregion

        public void Cleaner()
        {
            _controllers.Cleaner();
        }

        public void Initialization()
        {
            _controllers.Initialization();
        }
    }
}
