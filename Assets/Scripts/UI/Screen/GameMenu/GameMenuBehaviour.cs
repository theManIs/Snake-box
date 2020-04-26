using UnityEngine;
using UnityEngine.UI;


namespace Snake_box
{
    public sealed class GameMenuBehaviour : BaseUi
    {
        #region Fields
        
        [SerializeField] private Button _buttonAddBlocks;
        [SerializeField] private Button _buttonAddTurel;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _buttonAddTurel.onClick.AddListener(Call);
            _buttonAddBlocks.onClick.AddListener(AddBlock);
        }      

        private void OnDisable()
        {
            _buttonAddTurel.onClick.RemoveListener(Call);
            _buttonAddBlocks.onClick.RemoveListener(AddBlock);

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

        private void Call()
        {
           
        }

        #endregion
    }
}
