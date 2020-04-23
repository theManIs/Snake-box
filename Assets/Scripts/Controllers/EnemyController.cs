using System.Collections.Generic;


namespace Snake_box
{
    public sealed class EnemyController : IExecute, IInitialization
    {
        #region Fields

        private readonly List<IEnemy> _enemies = Data.ActiveEnemy;

        #endregion

        
        #region IExecute

        public void Execute()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].OnUpdate();
            }
        }

        #endregion

        
        #region IInitialization

        public void Initialization()
        {
        }

        #endregion

        
        #region Methods
        

        #endregion
    }
}
