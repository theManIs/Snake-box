namespace Snake_box
{
    public sealed class SlowEnemy : BaseEnemy
    {
        #region PrivateData

        private SlowEnemyData _data;

        #endregion

        
        #region ClassLifeCycle

        public SlowEnemy() : base(Data.Instance.SlowEnemy)
        {
            _data = Data.Instance.SlowEnemy;
            Type = EnemyType.Slow;
            GetTarget();
        }

        #endregion
    }
}
