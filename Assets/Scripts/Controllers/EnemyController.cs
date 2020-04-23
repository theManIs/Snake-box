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

        // private void AddEnemy(IEnemy enemy)
        // {
        //     if (!_enemies.Contains(enemy)&& !Data.ActiveEnemy.Contains(enemy))
        //     {
        //         _enemies.Add(enemy);
        //         Data.ActiveEnemy.Add(enemy);
        //     }
        //     
        // }

        // private void DelEnemy(IEnemy enemy)
        // {
        //     if (_enemies.Contains(enemy)&& Data.ActiveEnemy.Contains(enemy))
        //     {
        //         _enemies.Remove(enemy);
        //         Data.ActiveEnemy.Remove(enemy);
        //     }
        // }

        #endregion
    }
}
