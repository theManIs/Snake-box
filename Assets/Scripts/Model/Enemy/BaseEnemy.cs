namespace ExampleTemplate
{
    public abstract class BaseEnemy : IEnemy
    {
        #region PrivateData

        private float _hp;

        #endregion

        #region Properties

        public EnemyType Type { get; private set; }

        #endregion

        #region Methods

        public abstract void Move();
        public abstract void Spawn();

        #endregion
    }
}
