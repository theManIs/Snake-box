using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Snake_box
{
    public sealed class GameMenuBehaviour : BaseUi
    {
        #region Fields

        [SerializeField] private Sprite _spriteBlock;
        [SerializeField] private GameObject _panelTurretsType;
        [SerializeField] private GameObject _panelPause;
        [SerializeField] private Button _headSnake; 
        [SerializeField] private Button _pause;
        [SerializeField] private Button _mainMenu;
        [SerializeField] private Button _reset;
        [SerializeField] private Text _textEndGame;
        [SerializeField] private Button [] _buttonPlus;
        [SerializeField] private Button[] _buttonTurretsType;
        private int _selectButtonsIndex;
        private bool _isPause;

        #endregion
      

        #region UnityMethods

        private void OnEnable()
        {
            //_headSnake.onClick.AddListener(OpenActivites);//создать метод для активауии чего нибудь
            _buttonPlus[0].onClick.AddListener(delegate { AddBlock(0); });
            _buttonPlus[1].onClick.AddListener(delegate { AddBlock(1); });
            _buttonPlus[2].onClick.AddListener(delegate { AddBlock(2); });
            _buttonPlus[3].onClick.AddListener(delegate { AddBlock(3); });
            _buttonTurretsType[0].onClick.AddListener(delegate { AddTurret(0); });
            _buttonTurretsType[1].onClick.AddListener(delegate { AddTurret(1); });
            _buttonTurretsType[2].onClick.AddListener(delegate { AddTurret(2); });
            _buttonTurretsType[3].onClick.AddListener(delegate { AddTurret(3); });
            _mainMenu.onClick.AddListener(delegate { Services.Instance.TimeService.SetTimeScale(1); Services.Instance.LevelService.LoadMenu(); });
            _reset.onClick.AddListener(delegate { Services.Instance.TimeService.SetTimeScale(1); Services.Instance.LevelService.LoadLevel(0); });
            _pause.onClick.AddListener(Pause);
        }

        private void OnDisable()
        {
            //_headSnake.onClick.RemoveListener(OpenActivites);
            _buttonPlus[0].onClick.RemoveListener(delegate { AddBlock(0); });
            _buttonPlus[1].onClick.RemoveListener(delegate { AddBlock(1); });
            _buttonPlus[2].onClick.RemoveListener(delegate { AddBlock(2); });
            _buttonPlus[3].onClick.RemoveListener(delegate { AddBlock(3); });
            _buttonTurretsType[0].onClick.RemoveListener(delegate { AddTurret(0); });
            _buttonTurretsType[1].onClick.RemoveListener(delegate { AddTurret(1); });
            _buttonTurretsType[2].onClick.RemoveListener(delegate { AddTurret(2); });
            _buttonTurretsType[3].onClick.RemoveListener(delegate { AddTurret(3); });
            _mainMenu.onClick.RemoveListener(delegate { Services.Instance.LevelService.LoadLevel(0); });
            _reset.onClick.RemoveListener(delegate { Services.Instance.LevelService.LoadMenu(); });
            _pause.onClick.RemoveListener(Pause);
        }

        #endregion


        #region Methods               


        private void AddTurret(int i)
        {
            var _characterData = Data.Instance.Character;
            _characterData.CharacterBehaviour.GetBlock(_selectButtonsIndex).AddTurret();
            _buttonPlus[_selectButtonsIndex].image.sprite = _buttonTurretsType[i].image.sprite;
            _panelTurretsType.SetActive(false);
        }
        private void ChangeSprite(int numberButton)//меняем спрайт плюса на спрайт блока и активируем след кнопку плусик
        {
            if (_buttonPlus.Length > numberButton+1)
            {
             _buttonPlus[numberButton + 1].interactable = true;// включаем след. кнопку
            }
            _buttonPlus[numberButton].image.sprite = _spriteBlock;// меняем спрайт плюса на спрайт блока    
            Data.Instance.Character.CharacterBehaviour.AddBlock();
        }

        private void Pause()
        {
            if (!_isPause)
            {
                _panelPause.SetActive(true);
                Services.Instance.TimeService.SetTimeScale(0);
                _isPause = !_isPause;
            }
            else
            {
                _panelPause.SetActive(false);
                _isPause = !_isPause;
                Services.Instance.TimeService.SetTimeScale(1);
            }
        }

        private void AddBlock(int numberButton)//метод добавления турели если его нет то  
        {
           var _characterData = Data.Instance.Character;
            if (_characterData.CharacterBehaviour.GetBlock(numberButton))// если есть блок то активируем панель для выбопв турели
            {
                _panelTurretsType.SetActive (true);
                _selectButtonsIndex = numberButton;
            }
            else ChangeSprite(numberButton);
        }

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

        public void GetEndLevelText()
        {
            _pause.interactable = false;      
            if (Services.Instance.LevelService.IsTargetDestroed==true)
            {
                _textEndGame.text = "Congratulations!You Loser!";               
            }
            if (Services.Instance.LevelService.ActiveEnemies.Count <= 0)
            {                
                _textEndGame.text = "Congratulations!";               
            }
            Services.Instance.TimeService.SetTimeScale(0);
        }


        #endregion
    }
}
