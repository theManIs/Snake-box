using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Snake_box
{
    public sealed class EnemySpawnController : IInitialization, IExecute
    {
        #region Fields

        private List<BaseEnemy> _enemies = new List<BaseEnemy>();
        private TimeRemaining _spawnInvoker;
        private TimeRemaining _waveInvoker;
        private EnemySpawnData _enemySpawnData;
        private readonly LevelService _levelService;
        private float _spawnDelay;
        private float _waveDelay;
        private int _currentLevel;

        private int _wave;
        //private PoolObject _pool; //TODO добавить пул 

        #endregion


        #region ClassLifeCycle

        public EnemySpawnController()
        {
            _levelService = Services.Instance.LevelService;
        }
        

        #endregion

        
        #region IInitialization

        public void Initialization()
        {
            _enemySpawnData = Data.Instance.EnemySpawn;
            _spawnDelay = _enemySpawnData.LevelSpawnDatas[_currentLevel].SpawnDelay;
            _waveDelay = _enemySpawnData.LevelSpawnDatas[_currentLevel].WaveDelay;
            _currentLevel = _levelService.CurrentLevel;
            _spawnInvoker = new TimeRemaining(SpawnEnemy, _spawnDelay, true);
            _waveInvoker = new TimeRemaining(NextWave, _waveDelay);
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            if (_levelService.IsLevelStarted)
            {
                CustomDebug.Log("Level Started");
                LevelStart();
            }
            if (_levelService.IsSpawnNeed)
            {
                CustomDebug.Log("Spawn");
                SpawnEnemy();
            }
        }

        #endregion


        #region Methods

        private List<BaseEnemy> FillEnemyList()
        {
            List<BaseEnemy> _list = new List<BaseEnemy>();

            var wavesettings = _enemySpawnData.LevelSpawnDatas[_currentLevel].WaveSettings;
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
            if (_levelService.IsSpawnNeed)
            {
                _enemies = FillEnemyList();
                _levelService.IsSpawnNeed = false;
                _spawnInvoker.AddTimeRemaining();
            }

            if (_enemies.Count > 0)
            {
                var rnd = Random.Range(0, _enemies.Count);
                _enemies[rnd].Spawn();
                _enemies.RemoveAt(rnd);
            }

            if (_enemies.Count == 0)
            {
                _spawnInvoker.RemoveTimeRemaining();
                _levelService.IsWaveEnded = true;
                if (_enemySpawnData.LevelSpawnDatas[_currentLevel].WaveSettings.Count-1> _wave)
                {
                    _wave++;
                }
                else
                {
                    _levelService.IsLevelSpawnEnded = true;
                }
            }

            if (_levelService.IsWaveEnded && !_levelService.IsLevelSpawnEnded)
            {
                _waveInvoker.AddTimeRemaining();
            }
        }

        private void NextWave()
        {
            _levelService.IsSpawnNeed = true;
            _levelService.IsWaveEnded = false;
        }

        private void LevelStart()
        {
            _wave = 0;
            _levelService.IsLevelStarted = false;
        }
        
        #endregion
    }
}
