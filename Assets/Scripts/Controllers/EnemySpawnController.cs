using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


namespace Snake_box
{
    public sealed class EnemySpawnController : IInitialization, IExecute
    {
        public static event Action<IEnemy> Spawned;

        
        #region PrivateData

        private List<BaseEnemy> _enemies = new List<BaseEnemy>();
        private EnemySpawnData _enemySpawnData;
        private float _delay;
        private int _level;
        private int _wave;
        private bool _IsSpawnNeed;
        //private PoolObject _pool; //TODO добавить пул 

        #endregion

        
        #region IInitialization

        public void Initialization()
        {
            _enemySpawnData = Data.Instance.EnemySpawn;
            _enemies = FillEnemyList();
            _IsSpawnNeed = true;
            _delay = _enemySpawnData.LevelSpawnDatas[_wave].Delay;
            _wave = 0;// Волная в уровне
            _level = 0;// Задел на множество уровней
        }

        #endregion

        
        #region IExecute

        public void Execute()
        {
            if (_IsSpawnNeed)
            {
                if (_enemies.Count > 0)
                {
                    if (_delay <= 0.0f)
                    {
                        _delay = _enemySpawnData.LevelSpawnDatas[_level].Delay;
                        var rnd = Random.Range(0, _enemies.Count);
                        _enemies[rnd].Spawn();
                        Spawned(_enemies[rnd]);
                        _enemies.RemoveAt(rnd);
                    }
                    else
                        _delay -= Services.Instance.TimeService.DeltaTime();
                }
                else
                {
                    _IsSpawnNeed = false;
                    _wave++;
                }
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

        #endregion
    }
}
