namespace Snake_box
{
    public sealed class SlowEnemy : BaseEnemy
    {
        #region PrivateData

        private SlowEnemyData _data;

        #endregion

        
        #region ClassLifeCycle

        public SlowEnemy()
        {
            _data = Data.Instance.SlowEnemy;
            Type = EnemyType.Slow;
            prefab = _data.Prefab;
            _SpawnCenter = _data.SpawnCenter.transform.position;
            _spawnRadius = _data.SpawnRadius;
            _speed = _data.Speed;
            _hp = _data.Hp;
            _damage = _data.Damage;
            GetTarget();
        }

        #endregion
    }
}
