using UnityEngine;
using UnityEngine.AI;

namespace Snake_box
{
    public sealed class SimpleEnemy : BaseEnemy
    {
        #region PrivateData

        private SimpleEnemyData _data;
        private float _speed;
        private float _damage;

        #endregion

        #region ClassLifeCycles

        public SimpleEnemy() //TODO переделать по человечески
        {
            _data = Data.Instance.SimpleEnemy;
            Type = EnemyType.Simple;
            prefab = _data.prefab;
            _SpawnCenter = _data.SpawnCenter.transform.position;
            _spawnRadius = _data.SpawnRadius;
            _speed = _data.speed;
            _hp = _data.hp;
            _damage = _data.damage;
            GetTarget();

        }

        #endregion

        #region Methods

        public override void Spawn()
        {
            var enemy = GameObject.Instantiate(prefab,GetSpawnPoint(_SpawnCenter,_spawnRadius),Quaternion.identity);
            _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            _transform = enemy.transform;
            _isNeedNavMeshUpdate = true;
        }

        public override void OnUpdate()
        {
            if (_isNeedNavMeshUpdate)
            {
                _navMeshAgent.SetDestination(_target.transform.position);

                
                    _isNeedNavMeshUpdate = false;
                
            }
            HitCheck();
        }

        public void HitCheck()
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(_transform.position, 3.1f, colliders);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != null)
                    if (colliders[i].CompareTag("Target"))
                    {
                        Debug.Log("I Found It!");
                        Object.Destroy(colliders[i]);
                    }
            }
        }

        private void GetTarget()
        {
            _target = GameObject.FindWithTag("Target").transform;
        }

        private Vector3 GetSpawnPoint(Vector3 center, float distance)
        {
            Vector3 randomPos = Random.insideUnitSphere * distance + center;
            NavMesh.SamplePosition(randomPos, out var hit, distance,NavMesh.GetAreaFromName("Spawn"));
            return hit.position;
        }

        #endregion
    }
}
