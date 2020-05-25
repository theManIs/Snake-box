using System;
using System.Collections.Generic;
using System.IO;
// using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Snake_box
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        #region Fields
        
        [SerializeField] private string _shakeDataPath;
        [SerializeField] private string _characterDataPath;
        [SerializeField] private string _enemySpawnDataPath;
        [SerializeField] private string _levelSpawnDataPath;
        [SerializeField] private string _simpleEnemyDataPath;
        [SerializeField] private string _slowEnemyDataPath;
        [SerializeField] private string _fastEnemyDataPath;
        [SerializeField] private string _flyingEnemyDataPath;
        [SerializeField] private string _acceleratingEnemyDataPath;
        [SerializeField] private string _invisibleEnemyDataPath;
        [SerializeField] private string _spawnedEnemyDataPath;
        [SerializeField] private string _spawningEnemyDataPath;
        [SerializeField] private string _spikedEnemyDataPath;
        [SerializeField] private string _LevelDataPath;
        [SerializeField] private string _turretDataPath;
        [SerializeField] private string _borderDataPath;
        private static EnemySpawnData _enemySpawnData;
        private static LevelSpawnData _levelSpawnData;
        [SerializeField] private string _blockSnakeDataPath;
        private static ShakesData _shake;
        private static CharacterData _characterData;
        private static SimpleEnemyData _simpleEnemyData;
        private static SlowEnemyData _slowEnemyData;
        private static FastEnemyData _fastEnemyData;
        private static FlyingEnemyData _flyingEnemyData;
        private static AcceleratingEnemyData _acceleratingEnemyData;
        private static InvisibleEnemyData _invisibleEnemyData;
        private static SpawnedEnemyData _spawnedEnemyData;
        private static SpawningEnemyData _spawningEnemyData;
        private static SpikedEnemyData _spikedEnemyData;
        private static LevelData _levelData;
        private static BlockSnakeData _blockSnake;
        private static TurretData _turretData;
        private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));
        
        #endregion
        

        #region Properties

        public static Data Instance => _instance.Value;

        public BlockSnakeData BlockSnake
        {
            get
            {
                if (_blockSnake == null)
                {
                    _blockSnake = Load<BlockSnakeData>("Data/" + Instance._blockSnakeDataPath);
                }

                return _blockSnake;
            }
        }

        public ShakesData Shakes
        {
            get
            {
                if (_shake == null)
                {
                    _shake = Load<ShakesData>("Data/" + Instance._shakeDataPath);
                }

                return _shake;
            }
        }

        public CharacterData Character
        {
            get
            {
                if (_characterData == null)
                {
                    _characterData = Load<CharacterData>("Data/" + Instance._characterDataPath);
                }

                return _characterData;
            }
        }

        public EnemySpawnData EnemySpawn
        {
            get
            {
                if (_enemySpawnData == null)
                {
                    _enemySpawnData = Load<EnemySpawnData>("Data/" + Instance._enemySpawnDataPath);
                }

                return _enemySpawnData;
            }
        }

        public SimpleEnemyData SimpleEnemy
        {
            get
            {
                if (_simpleEnemyData == null)
                {
                    _simpleEnemyData = Load<SimpleEnemyData>("Data/" + Instance._simpleEnemyDataPath);
                }

                return _simpleEnemyData;
            }
        }
        
        public SlowEnemyData SlowEnemy
        {
            get
            {
                if (_slowEnemyData == null)
                {
                    _slowEnemyData = Load<SlowEnemyData>("Data/" + Instance._slowEnemyDataPath);
                }

                return _slowEnemyData;
            }
        }
        
        public FastEnemyData FastEnemy
        {
            get
            {
                if (_fastEnemyData == null)
                {
                    _fastEnemyData = Load<FastEnemyData>("Data/" + Instance._fastEnemyDataPath);
                }

                return _fastEnemyData;
            }
        }

        public FlyingEnemyData FlyingEnemy
        {
            get
            {
                if (_flyingEnemyData == null)
                {
                    _flyingEnemyData = Load<FlyingEnemyData>("Data/" + Instance._flyingEnemyDataPath);
                }

                return _flyingEnemyData;
            }
        }
        
        public AcceleratingEnemyData AcceleratingEnemy
        {
            get
            {
                if (_acceleratingEnemyData == null)
                {
                    _acceleratingEnemyData = Load<AcceleratingEnemyData>("Data/" + Instance._acceleratingEnemyDataPath);
                }

                return _acceleratingEnemyData;
            }
        }
        
        public InvisibleEnemyData InvisibleEnemy
        {
            get
            {
                if (_invisibleEnemyData == null)
                {
                    _invisibleEnemyData = Load<InvisibleEnemyData>("Data/" + Instance._invisibleEnemyDataPath);
                }

                return _invisibleEnemyData;
            }
        }
        
        public SpawnedEnemyData SpawnedEnemy
        {
            get
            {
                if (_spawnedEnemyData == null)
                {
                    _spawnedEnemyData = Load<SpawnedEnemyData>("Data/" + Instance._spawnedEnemyDataPath);
                }

                return _spawnedEnemyData;
            }
        }
        
        public SpawningEnemyData SpawningEnemy
        {
            get
            {
                if (_spawningEnemyData == null)
                {
                    _spawningEnemyData = Load<SpawningEnemyData>("Data/" + Instance._spawningEnemyDataPath);
                }

                return _spawningEnemyData;
            }
        }
        
        public SpikedEnemyData SpikedEnemy
        {
            get
            {
                if (_spikedEnemyData == null)
                {
                    _spikedEnemyData = Load<SpikedEnemyData>("Data/" + Instance._spikedEnemyDataPath);
                }

                return _spikedEnemyData;
            }
        }

        public LevelSpawnData LevelSpawn
        {
            get
            {
                if (_levelSpawnData == null)
                {
                    _levelSpawnData = Load<LevelSpawnData>("Data/" + Instance._levelSpawnDataPath);
                }

                return _levelSpawnData;
            }
        }

        public LevelData LevelData
        {
            get
            {
                if (_levelData == null)
                {
                    _levelData = Load<LevelData>("Data/" + Instance._LevelDataPath);
                }

                return _levelData;
            }
        }

        public TurretData TurretData
        {
            get
            {
                if (_turretData == null)
                {
                    _turretData = Load<TurretData>("Data/" + Instance._turretDataPath);
                }

                return _turretData;
            }
        }

        public BordersData BordersData => Load<BordersData>("Data/" + Instance._borderDataPath);

        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    
        #endregion
    }
}
