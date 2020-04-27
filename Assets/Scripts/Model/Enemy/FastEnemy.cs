namespace Snake_box
{
    public sealed class FastEnemy : BaseEnemy
    {
        #region PrivateData

        private FastEnemyData _data;

        #endregion

        
        #region ClassLifeCycle

        public FastEnemy()
        {
            _data = Data.Instance.FastEnemy;
            Type = EnemyType.Fast;
            _prefab = _data.Prefab;
            _spawnRadius = _data.SpawnRadius;
            _speed = _data.Speed;
            _hp = _data.Hp;
            _damage = _data.Damage;
            GetTarget();
        }

        #endregion
    }
}
