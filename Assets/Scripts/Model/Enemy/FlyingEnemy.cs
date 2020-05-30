namespace Snake_box
{
    public sealed class FlyingEnemy : BaseEnemy
    {
        #region PrivateData

        private FlyingEnemyData _data;

        #endregion

        
        #region ClassLifeCycle

        public FlyingEnemy() : base(Data.Instance.FlyingEnemy)
        {
            _data = Data.Instance.FlyingEnemy;
            Type = EnemyType.Flying;
            GetTarget();
        }

        #endregion
    }
}
