namespace Snake_box
{
    public class BonusCoins : BaseBonus
    {
        #region Fields

        private BonusCoinsData _bonusCoinsData;
        private int _worldCoins;
        private int _localCoins;

        #endregion


        #region Methods

        public BonusCoins() : base(Data.Instance.BonusCoinsData)
        {
            _bonusCoinsData = Data.Instance.BonusCoinsData;           
            _worldCoins = _bonusCoinsData.WorldCoins;
            _localCoins = _bonusCoinsData.LocalCoins;
        }
        public override void Use()
        {
            base.Use();
            Wallet.PutWorldCoins(_worldCoins);
            Wallet.PutLocalCoins(_localCoins);
        }

        #endregion

    }
}
