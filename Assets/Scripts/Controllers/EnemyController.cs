using System.Collections.Generic;


namespace Snake_box
{
    public sealed class EnemyController : IExecute, IInitialization
    {
        #region PrivateData

        private LevelService _levelService = Services.Instance.LevelService;
        private readonly List<IEnemy> _enemies = Services.Instance.LevelService.ActiveEnemies;
        

        #endregion


        #region IExecute

        public void Execute()
        {
            if (_enemies.Count > 0)
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
