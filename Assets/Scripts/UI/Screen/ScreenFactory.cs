using UnityEngine;


namespace BottomlessCloset
{
    public sealed class ScreenFactory
    {
        #region Fields

        private GameMenuBehaviour _gameMenu;
        private MainMenuBehaviour _mainMenu;
        private Canvas _canvas;

        #endregion


        #region ClassLifeCycles

        public ScreenFactory()
        {
            var resources = CustomResources.Load<Canvas>(AssetsPathGameObject.GameObjects[GameObjectType.Canvas]);
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity);
        }

        #endregion
        

        #region Methods

        public GameMenuBehaviour GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var resources = CustomResources.Load<GameMenuBehaviour>(AssetsPathScreen.Screens[ScreenType.GameMenu].Screen);
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _gameMenu;
        }

        public MainMenuBehaviour GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var resources = CustomResources.Load<MainMenuBehaviour>(AssetsPathScreen.Screens[ScreenType.MainMenu].Screen);
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _mainMenu;
        }

        #endregion
    }
}
