namespace Snake_box
{
    public sealed class SimpleEnemy : BaseEnemy
    {
        #region PrivateData

        private SimpleEnemyData _data;

        #endregion

        
        #region ClassLifeCycles

        public SimpleEnemy()
        {
            _data = Data.Instance.SimpleEnemy;
            Type = EnemyType.Simple;
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
