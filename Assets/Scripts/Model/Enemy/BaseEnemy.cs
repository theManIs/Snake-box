using ExampleTemplate;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace Snake_box
{
    public abstract class BaseEnemy : IEnemy, IDamageAddressee
    {
        #region PrivateData

        protected ArmorType _armor;
        protected NavMeshAgent _navMeshAgent;
        protected GameObject _prefab;
        protected GameObject _enemyObject;
        protected GameObject _spawnCenter;
        protected Transform _transform;
        protected Transform _target;
        protected LevelService _levelService = Services.Instance.LevelService;
        protected float _hp;
        protected float _spawnRadius;
        protected float _speed;
        protected float _damage;
        protected float _meleeHitRange;
        protected bool _isNeedNavMeshUpdate = false;
        protected bool _isValidTarget;

        #endregion


        #region ClassLifeCycle

        public BaseEnemy(BaseEnemyData data)
        {
            _prefab = data.Prefab;
            _spawnRadius = data.SpawnRadius;
            _speed = data.Speed;
            _hp = data.Hp;
            _damage = data.Damage;
            _armor = data.ArmorType;
            _meleeHitRange = data.MeleeHitRange;
        }

        #endregion
        

        #region Properties

        public EnemyType Type { get; protected set; }

        #endregion


        #region IEnemy

        public virtual void Spawn()
        {
            if (_levelService.Target == null || _levelService.Spawn == null)
            {
               _levelService.FindGameObject(); 
            }
            _spawnCenter = _levelService.Spawn;
            _target = _levelService.Target.transform;
            _enemyObject = GameObject.Instantiate(_prefab, GetSpawnPoint(_spawnCenter), Quaternion.identity);
            _navMeshAgent = _enemyObject.GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _speed;
            _transform = _enemyObject.transform;
            _isNeedNavMeshUpdate = true;
            _isValidTarget = true;
            if (!_levelService.ActiveEnemies.Contains(this))
                _levelService.ActiveEnemies.Add(this);
        }

        public virtual void OnUpdate()

        {
            if (_isNeedNavMeshUpdate)
            {
                if (_target != null)
                    _navMeshAgent.SetDestination(_target.transform.position);
                _isNeedNavMeshUpdate = false;
            }

            HitCheck();
        }

        public Transform GetTransform() => _transform;

        public bool AmIDestroyed()
        {
            return _enemyObject == null;
        }

        public Vector3 GetPosition() => _transform.position;
        public EnemyType GetEnemyType() => Type;
        public bool IsValidTarget() => _isValidTarget;

        #endregion


        #region Methods

        private void HitCheck()
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(_transform.position, _meleeHitRange, colliders);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != null)
                {
                    if (colliders[i].CompareTag(TagManager.GetTag(TagType.Target)))
                    {
                        var mainBuilding = colliders[i].GetComponent<MainBuild>();
                        mainBuilding.GetDamage(_damage);
                    }
                    else if (colliders[i].CompareTag(TagManager.GetTag(TagType.Player)))
                    {
                        Data.Instance.Character.SetHp(-_damage);
                    }
                }

            }
        }

        protected virtual void GetTarget()
        {    
            _target = GameObject.FindWithTag(TagManager.GetTag(TagType.Target)).transform;
        }

        protected virtual Vector3 GetSpawnPoint(GameObject center)
        {
            var volume = center.GetComponent<NavMeshModifierVolume>();
            var sizeX = volume.size.x;
            var sizeZ = volume.size.z;
            var position = volume.transform.position;
            var randomPos = new Vector3(position.x - Random.Range(-sizeX / 2, sizeX / 2), position.y,
                position.z - Random.Range(-sizeZ / 2, sizeZ / 2));
            NavMesh.SamplePosition(randomPos, out var hit, _spawnRadius, NavMesh.GetAreaFromName("Spawn"));
            return hit.position;
        }

        protected virtual void GetDamage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                if (_levelService.ActiveEnemies.Contains(this))
                    _levelService.ActiveEnemies.Remove(this);
                Object.Destroy(_enemyObject);
                if (_levelService.ActiveEnemies.Count == 0)
                {
                    _levelService.EndLevel();
                }
            }
        }

        #endregion


        #region IDamageAdressee

        public void RegisterDamage(float damageAmount, ArmorTypes damageType)
        {
            GetDamage(damageAmount);
        }

        #endregion
    }
}
