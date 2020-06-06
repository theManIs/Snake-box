using UnityEngine;
using UnityEngine.AI;

namespace Snake_box
{
    public sealed class SpawnedEnemy : BaseEnemy
    {
        #region PrivateData

        private SpawnedEnemyData _data;

        #endregion

        
        #region ClassLifeCycle

        public SpawnedEnemy() : base(Data.Instance.SpawnedEnemy)
        {
            _data = Data.Instance.SpawnedEnemy;
            Type = EnemyType.Spawned;
            GetTarget();
        }

        #endregion


        #region IEnemy

        public override void Spawn(Vector3 spawnpos)
        {
            if (_levelService.Target == null)
            {
                _levelService.FindGameObject(); 
            }
            _target = _levelService.Target.transform;
            _enemyObject = GameObject.Instantiate(_prefab, spawnpos, Quaternion.identity);
            _navMeshAgent = _enemyObject.GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _speed;
            _transform = _enemyObject.transform;
            _isNeedNavMeshUpdate = true;
            _isValidTarget = true;
            if (!_levelService.ActiveEnemies.Contains(this))
                _levelService.ActiveEnemies.Add(this);
        }

        #endregion
    }
}
