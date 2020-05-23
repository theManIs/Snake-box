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
            _prefab = _data.Prefab;
            _spawnRadius = _data.SpawnRadius;
            _speed = _data.Speed;
            _hp = _data.Hp;
            _damage = _data.Damage;
            _meleeHitRange = _data.MeleeHitRange;
            GetTarget();
        }

        #endregion
    }
}
