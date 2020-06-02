using System.Collections.Generic;


namespace Snake_box
{
    public sealed class EnemyController : IExecute, IInitialization, ICleanUp
    {
        #region Fields

        private readonly LevelService _levelService;
        private List<IEnemy> _enemies => Services.Instance.LevelService.ActiveEnemies;


        #endregion


        #region ClassLifeCycle

        public EnemyController()
        {
            _levelService = Services.Instance.LevelService;
        }

        public void Clean()
        {
            var enemies = _enemies.ToArray();

            foreach (var enemy in enemies)
                ((BaseEnemy)enemy).Destroy();
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
