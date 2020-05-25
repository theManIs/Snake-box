namespace Snake_box
{
    public sealed class FastEnemy : BaseEnemy
    {
        #region PrivateData

        private FastEnemyData _data;

        #endregion

        
        #region ClassLifeCycle

        public FastEnemy() : base(Data.Instance.FastEnemy)
        {
            _data = Data.Instance.FastEnemy;
            Type = EnemyType.Fast;
            GetTarget();
        }

        #endregion
    }
}
