using System.Collections.Generic;

namespace ExampleTemplate
{
    public class EnemyController : IExecute, IInitialization
    {
        
        #region Fields

        private List<IEnemy> _enemies = new List<IEnemy>();

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
            EnemySpawnController.Spawned += AddEnemy;
        }

        #endregion

        #region Methods

        private void AddEnemy(IEnemy enemy)
        {
            _enemies.Add(enemy);
        }

        #endregion
    }
}
