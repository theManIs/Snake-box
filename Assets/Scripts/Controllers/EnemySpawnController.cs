using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleTemplate
{
    public class EnemySpawnController : IInitialization, IExecute
    {
        public static event Action<IEnemy> Spawned;
        
        #region PrivateData

        private List<IEnemy> _enemies = new List<IEnemy>();

        private bool _IsSpawnNeed;
        //private PoolObject _pool; //TODO добавить пул 

        #endregion

        #region IInitialization

        public void Initialization()
        {
            _enemies = FillEnemyList();
            _IsSpawnNeed = true;
        }

        #endregion

        #region IExecute

        public void Execute()
        {
            if (_IsSpawnNeed)
            {
                for (int i = 0; i < _enemies.Count; i++)
                {
                    _enemies[i].Spawn();
                    Spawned(_enemies[i]);
                }

                _IsSpawnNeed = false;
            }
        }

        #endregion

        #region Methods

        private List<IEnemy> FillEnemyList()
        {
            List<IEnemy> _list = new List<IEnemy>();
            _list.Add(new SimpleEnemy());
            return _list;
        }

        #endregion
    }
}
