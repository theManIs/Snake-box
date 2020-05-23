using System.Collections.Generic;


namespace Snake_box
{
    public sealed class EnemyController : IExecute, IInitialization
    {
        #region Fields

        private readonly LevelService _levelService;
        private readonly List<IEnemy> _enemies;
        

        #endregion


        #region ClassLifeCycle

        public EnemyController()
        {
            _levelService = Services.Instance.LevelService;
            _enemies = Services.Instance.LevelService.ActiveEnemies;
        }
        

        #endregion

        
        #region IExecute

        public void Execute()
        {
            if (_enemies.Count > 0)
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    _enemies[i].OnUpdate();
                }
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
