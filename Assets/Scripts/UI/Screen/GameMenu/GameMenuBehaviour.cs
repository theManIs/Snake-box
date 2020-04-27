using UnityEngine;
using UnityEngine.UI;


namespace Snake_box
{
    public sealed class GameMenuBehaviour : BaseUi
    {
        #region Fields
        
        [SerializeField] private Button _buttonAddBlocks;
        [SerializeField] private Button _buttonAddTurel1;
        [SerializeField] private Button _buttonAddTurel2;
        [SerializeField] private Button _buttonAddTurel3;
        [SerializeField] private Button _buttonAddTurel4;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _buttonAddBlocks.onClick.AddListener(AddBlock);
            _buttonAddTurel1.onClick.AddListener(delegate { Call(0);} );
            _buttonAddTurel2.onClick.AddListener(delegate { Call(1);} );
            _buttonAddTurel3.onClick.AddListener(delegate { Call(2);} );
            _buttonAddTurel4.onClick.AddListener(delegate { Call(3);} );
        }       

        private void OnDisable()
        {
            _buttonAddBlocks.onClick.RemoveListener(AddBlock);
            _buttonAddTurel1.onClick.RemoveListener(delegate { Call(0); });
            _buttonAddTurel2.onClick.RemoveListener(delegate { Call(1); });
            _buttonAddTurel3.onClick.RemoveListener(delegate { Call(2); });
            _buttonAddTurel4.onClick.RemoveListener(delegate { Call(3); });
        }

        #endregion


        #region Methods

        private void AddBlock()
        {
           var _characterData = Data.Instance.Character;
            _characterData.CharacterBehaviour.AddBlock();
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

        private void Call(int numberButton)
        {
            var _characterData = Data.Instance.Character;
            _characterData.CharacterBehaviour.GetBlock(numberButton).AddTurret();
        }

        #endregion
    }
}
