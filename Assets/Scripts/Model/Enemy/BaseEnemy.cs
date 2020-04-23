using System;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Snake_box
{
    public abstract class BaseEnemy : IEnemy
    {

        #region PrivateData

        protected NavMeshAgent _navMeshAgent;
        protected GameObject _prefab;
        protected GameObject _spawnCenter = Services.Instance.LevelService.Spawn;
        protected Transform _transform;
        protected Transform _target = Services.Instance.LevelService.Target.transform;
        protected float _hp;
        protected float _spawnRadius;
        protected float _speed;
        protected float _damage;
        protected bool _isNeedNavMeshUpdate = false;

        #endregion

        
        #region Properties

        public EnemyType Type { get; protected set; }

        #endregion

        
        #region Methods

        public virtual void Spawn()
        {
            var enemy = GameObject.Instantiate(_prefab, GetSpawnPoint(_spawnCenter), Quaternion.identity);
            _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _speed;
            _transform = enemy.transform;
            _isNeedNavMeshUpdate = true;
            Data.ActiveEnemy.Add(this);
        }

        public void HitCheck()
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(_transform.position, 3.1f, colliders);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != null)
                    if (colliders[i].CompareTag(TagManager.GetTag(TagType.Target)))
                    {
                        Object.Destroy(colliders[i].gameObject);
                    }
            }
        }

        protected virtual void GetTarget()
        {
            _target = GameObject.FindWithTag(TagManager.GetTag(TagType.Target)).transform;
        }

        private Vector3 GetSpawnPoint(GameObject center)
        {
            var volume = center.GetComponent<NavMeshModifierVolume>();
            var sizeX = volume.size.x;
            var sizeZ = volume.size.z;
            var position = volume.transform.position;
            var randomPos = new Vector3(position.x-Random.Range(-sizeX/2,sizeX/2),position.y,position.z-Random.Range(-sizeZ/2,sizeZ/2));
            NavMesh.SamplePosition(randomPos, out var hit, _spawnRadius, NavMesh.GetAreaFromName("Spawn"));
            return hit.position;
        }

        public void GetDamage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Data.ActiveEnemy.Remove(this);
                Object.Destroy(_transform.gameObject);
            }
        }
        
        public virtual void OnUpdate()

        {
            if (_isNeedNavMeshUpdate)
            {
                if(_target!= null)
                    _navMeshAgent.SetDestination(_target.transform.position);
                _isNeedNavMeshUpdate = false;
            }

            HitCheck();
        }
        #endregion
    }
}
