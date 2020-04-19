namespace Snake_box
{
    public sealed class FastEnemy: BaseEnemy
    {
        #region PrivateData

        private FastEnemyData _data;

        #endregion

        #region ClassLifeCycle

        public FastEnemy()
        {
            _data = Data.Instance.FastEnemy;
            Type = EnemyType.Fast;
            prefab = _data.prefab;
            _SpawnCenter = _data.SpawnCenter.transform.position;
            _spawnRadius = _data.SpawnRadius;
            _speed = _data.speed;
            _hp = _data.hp;
            _damage = _data.damage;
            GetTarget();
        }

        #endregion
    }
}
