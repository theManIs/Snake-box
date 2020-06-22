namespace Snake_box
{
    public sealed class SimpleEnemy : BaseEnemy
    {
        #region PrivateData

        private SimpleEnemyData _data;

        #endregion

        
        #region ClassLifeCycles

        public SimpleEnemy() : base(Data.Instance.SimpleEnemy)
        {
            _data = Data.Instance.SimpleEnemy;
            Type = EnemyType.Simple;
            GetTarget();
        }

        #endregion
    }
}
