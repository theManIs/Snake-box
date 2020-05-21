using System;

namespace Snake_box
{
    public sealed class SpawningEnemy : BaseEnemy
    {
        #region PrivateData

        private SpawningEnemyData _data;

        #endregion


        #region ClassLifeCycle

        public SpawningEnemy() : base(Data.Instance.SpawningEnemy)
        {
            _data = Data.Instance.SpawningEnemy;
            Type = EnemyType.Spawning;
            GetTarget();
        }

        #endregion


        #region Methods

        protected override void GetDamage(float damage)
        {
            base.GetDamage(damage);
            if (_hp <= 0)
            {
                for (int i = 0; i < _data.Count; i++)
                {
                    var spawnedEnemy = new SpawnedEnemy();
                    spawnedEnemy.Spawn(_enemyObject.transform.position);
                }
            }
        }
    }

    #endregion
}

