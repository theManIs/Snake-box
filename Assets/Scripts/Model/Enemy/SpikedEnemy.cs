namespace Snake_box
{
    public sealed class SpikedEnemy : BaseEnemy
    {
        #region PrivateData

        private SpikedEnemyData _data;

        #endregion

        
        #region ClassLifeCycle

        public SpikedEnemy() : base(Data.Instance.SpikedEnemy)
        {
            _data = Data.Instance.SpikedEnemy;
            Type = EnemyType.Spiked;
            GetTarget();
        }

        #endregion
    }
}
