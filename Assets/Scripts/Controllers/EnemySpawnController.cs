using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


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
                while (_enemies.Count>0)
                {
                    var rnd = Random.Range(0, _enemies.Count);
                    _enemies[rnd].Spawn();
                    Spawned(_enemies[rnd]);
                    _enemies.RemoveAt(rnd);
                    Debug.Log(_enemies.Count);
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

            for (int i = 0; i < wavesettings[0].FastEnemyCount; i++)
            {
                //TODO Add Enemy to list
            }

            for (int i = 0; i < wavesettings[0].SlowEnemyCount; i++)
            {
                //TODO Add Enemy to list
            }

            for (int i = 0; i < wavesettings[0].FlyingEnemyCount; i++)
            {
                //TODO Add Enemy to list
            }

            return _list;
        }

        #endregion
    }
}
