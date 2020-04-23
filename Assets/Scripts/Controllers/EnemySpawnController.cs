using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Snake_box
{
    public sealed class EnemySpawnController : IInitialization, IExecute
    {
        #region PrivateData

        private List<BaseEnemy> _enemies = new List<BaseEnemy>();
        private TimeRemaining _spawnInvoker;
        private EnemySpawnData _enemySpawnData;
        private float _delay;
        private int _level;

        private int _wave;
        //private PoolObject _pool; //TODO добавить пул 

        #endregion


        #region IInitialization

        public void Initialization()
        {
            _enemySpawnData = Data.Instance.EnemySpawn;
            _delay = _enemySpawnData.LevelSpawnDatas[_wave].Delay;
            _level = Services.Instance.LevelService.CurrentLevel;
            _wave = 0; // Волная в уровне
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            if (Services.Instance.LevelService.IsSpawnNeed)
            {
                _spawnInvoker = new TimeRemaining(SpawnEnemy, _delay,true);
                SpawnEnemy();
            }
        }

        #endregion


        #region Methods

        private List<BaseEnemy> FillEnemyList()
        {
            List<BaseEnemy> _list = new List<BaseEnemy>();

            var wavesettings = _enemySpawnData.LevelSpawnDatas[_level].WaveSettings;
            for (int i = 0; i < wavesettings[_wave].SimpleEnemyCount; i++)
            {
                _list.Add(new SimpleEnemy());
            }

            for (int i = 0; i < wavesettings[_wave].FastEnemyCount; i++)
            {
                _list.Add(new FastEnemy());
            }

            for (int i = 0; i < wavesettings[_wave].SlowEnemyCount; i++)
            {
                _list.Add(new SlowEnemy());
            }

            for (int i = 0; i < wavesettings[_wave].FlyingEnemyCount; i++)
            {
                _list.Add(new FlyingEnemy());
            }

            return _list;
        }

        private void SpawnEnemy()
        {
            if (Services.Instance.LevelService.IsSpawnNeed)
            {
                _enemies = FillEnemyList();
                Services.Instance.LevelService.IsSpawnNeed = false;
                _spawnInvoker.AddTimeRemaining();
            }

            if (_enemies.Count > 0)
            {
                Debug.Log("Spawn");
                var rnd = Random.Range(0, _enemies.Count);
                _enemies[rnd].Spawn();
                _enemies.RemoveAt(rnd);
            }
            else
            {
                _spawnInvoker.RemoveTimeRemaining();
                _wave++;
            }
        }

        #endregion
    }
}
