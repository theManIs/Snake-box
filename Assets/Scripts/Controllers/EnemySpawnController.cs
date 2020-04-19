using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    public class EnemySpawnController : IInitialization, IExecute
    {
        public static event Action<IEnemy> Spawned;

        #region PrivateData

        private List<BaseEnemy> _enemies = new List<BaseEnemy>();
        private EnemySpawnData _enemySpawnData;
        private int level;
        private int wave;


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

        private List<BaseEnemy> FillEnemyList()
        {
            List<BaseEnemy> _list = new List<BaseEnemy>();
            _enemySpawnData = Data.Instance.EnemySpawn;
            var wavesettings = _enemySpawnData.LevelSpawnDatas[wave].WaveSettings;
            for (int i = 0; i < wavesettings[0].SimpleEnemyCount; i++)
            {
                _list.Add(new SimpleEnemy());
            }

            return _list;
        }

        #endregion
    }
}
