using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Snake_box
{
	public class EnemySpawnControler : IExecute, IInitialization
	{
        private Vector3[] _spawnPoints;
        private Queue<SingleEnemySpawnData> _enemiesToSpawnQueue;
        
        /// <summary>
        /// Возвращает истинну, если все враги из списка были заспауненны
        /// </summary>
        private bool isSpawningFinished => _enemiesToSpawnQueue.Count == 0;

        #region IExecute

        public void Execute()
        {
            while (!isSpawningFinished && _enemiesToSpawnQueue.Peek().SpawnTiming <= Services.Instance.TimeService.TimeSinceLevelStart())
            {
                SpawnNextEnemy();
            }
            if (isSpawningFinished)
                Services.Instance.LevelService.IsLevelSpawnEnded = true;
        }

        #endregion

        #region IInitialization

        public void Initialization()
        {
            //Инициализация списка спауна
            //Получаем Scriptable Object список спауна
            var enemySpawnList = Data.Instance.AllSpawnListsData.GetEnemySpawnListByLevelType(Services.Instance.LevelService.CurrentLevel);
            //Извлекаем из него массив элементов - записей о спауне отдельных врагов
            var singleEnemySpawnDatas = enemySpawnList.Enemies;
            //Сортируем его по таймингу спауна по ворастанию
            singleEnemySpawnDatas = singleEnemySpawnDatas.OrderBy(x => x.SpawnTiming).ToArray();
            //Закидываем это всё в очередь в таком порядке, чтобы запси с ранними таймингами были в голове очереди
            _enemiesToSpawnQueue = new Queue<SingleEnemySpawnData>();
            foreach (var enemySpawnData in singleEnemySpawnDatas)
                _enemiesToSpawnQueue.Enqueue(enemySpawnData);

            //Инициализация точек спауна
            //Создаются массивы точек спауна и их ID соответственно
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(TagManager.GetTag(TagType.Spawn));
            int[] spawnPointIds = new int[spawnPoints.Length];
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                string idString = string.Empty;//строка, содержащая все цифры из имени объекта
                foreach(char c in spawnPoints[i].name)
                {
                    if (IsDigit(c))
                        idString += c;
                }
                int id = int.Parse(idString);
                spawnPointIds[i] = id;
            }
            //Каждая точка спауна занимает место в массиве _spawnPoints с индексом равным своему ID
            _spawnPoints = new Vector3[spawnPointIds.Max() + 1];
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                _spawnPoints[spawnPointIds[i]] = spawnPoints[i].transform.position;
            }
        }

        #endregion

        #region Methods

        private void SpawnNextEnemy()
        {
            var enemySpawnData = _enemiesToSpawnQueue.Dequeue();
            BaseEnemy enemy = null;
            switch (enemySpawnData.EnemyType)
            {
                case EnemyType.Simple:
                    enemy = new SimpleEnemy();
                    break;
                case EnemyType.Fast:
                    enemy = new FastEnemy();
                    break;
                case EnemyType.Slow:
                    enemy = new SlowEnemy();
                    break;
                case EnemyType.Flying:
                    enemy = new FlyingEnemy();
                    break;
                case EnemyType.Accelerating:
                    enemy = new AcceleratingEnemy();
                    break;
                case EnemyType.Invisible:
                    enemy = new InvisibleEnemy();
                    break;
                case EnemyType.Spawned:
                    enemy = new SpawnedEnemy();
                    break;
                case EnemyType.Spawning:
                    enemy = new SpawningEnemy();
                    break;
                case EnemyType.Spiked:
                    enemy = new SpikedEnemy();
                    break;
            }
            enemy.Spawn(_spawnPoints[enemySpawnData.SpawnPointId]);
        }

        private bool IsDigit(char character)
        {
            int parseResult;
            return int.TryParse(character.ToString(), out parseResult);
        }

        #endregion
    }
}
