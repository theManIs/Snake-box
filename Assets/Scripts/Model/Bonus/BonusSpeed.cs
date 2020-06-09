namespace Snake_box
{
    public class BonusSpeed : BaseBonus
    {

        #region Fields

        private BonusSpeedData _bonusSpeedData;
        private TimeRemaining _spawnInvoker;
        private int _speed;
        private int _timeEffect;

        #endregion


        #region Methods

        public BonusSpeed() : base(Data.Instance.BonusSpeedData)
        {
            _bonusSpeedData = Data.Instance.BonusSpeedData;
            _speed = _bonusSpeedData.Speed;
            _timeEffect = _bonusSpeedData.TimeEffect;
            _spawnInvoker = new TimeRemaining(StopEffect, _timeEffect);           
        }

        public override void Use()
        {
            base.Use();
            Services.Instance.LevelService.CharacterBehaviour.SnakeSpeed += _speed;
            _spawnInvoker.AddTimeRemaining();
        }

        public void StopEffect()
        {
            Services.Instance.LevelService.CharacterBehaviour.SnakeSpeed -= _speed;
            _spawnInvoker.RemoveTimeRemaining();
        }

        #endregion

    }
}
