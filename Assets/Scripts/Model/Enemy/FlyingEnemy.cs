namespace Snake_box
{
    public sealed class FlyingEnemy: BaseEnemy
    {
        #region PrivateData

        private FlyingEnemyData _data;

        #endregion

        #region ClassLifeCycle

        public FlyingEnemy()
        {
            _data = Data.Instance.FlyingEnemy;
            Type = EnemyType.Flying;
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
