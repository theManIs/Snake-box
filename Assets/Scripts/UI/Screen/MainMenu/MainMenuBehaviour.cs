using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Snake_box
{
    public sealed class MainMenuBehaviour : BaseUi
    {
        #region Fields
        
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Text _currentLevelLabel;
        [SerializeField] private Button _exitButton;

        private LocationService _locationService;
        
        #endregion 


        #region UnityMethods

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(StartGameButtonClick);
            _settingsButton.onClick.AddListener(ShowSettingsButtonClick);
            _exitButton.onClick.AddListener(ExitButtonClick);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(StartGameButtonClick);
            _settingsButton.onClick.RemoveListener(ShowSettingsButtonClick);
            _exitButton.onClick.RemoveListener(ExitButtonClick);
        }

        #endregion
        
        
        #region Methods

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void StartGameButtonClick()
        {
            SceneManager.LoadScene(1);            
        }

        private void ShowSettingsButtonClick()
        {
            ScreenInterface.GetInstance().Execute(ScreenType.Settings);
        }
        private void ExitButtonClick()
        {
            Application.Quit();
        }

        #endregion
    }
}
