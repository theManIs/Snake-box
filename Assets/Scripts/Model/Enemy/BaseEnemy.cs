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
        protected Transform _transform;
        protected Transform _target;
        protected LevelService _levelService = Services.Instance.LevelService;
        protected float _hp;
        protected float _speed;
        protected float _damage;
        protected float _meleeHitRange;
        protected bool _isNeedNavMeshUpdate = false;
        protected bool _isValidTarget;
        protected int _killReward;

        #endregion


        #region ClassLifeCycle

        protected BaseEnemy(BaseEnemyData data)
        {
            _prefab = data.Prefab;
            _speed = data.Speed;
            _hp = data.Hp;
            _damage = data.Damage;
            _armor = data.ArmorType;
            _meleeHitRange = data.MeleeHitRange;
            _killReward = data.KillReward;
        }

        #endregion
        

        #region Properties

        public EnemyType Type { get; protected set; }

        #endregion


        #region IEnemy

        public virtual void Spawn(Vector3 position)
        {
            if (_levelService.Target == null)
            {
               _levelService.FindGameObject(); 
            }
            _target = _levelService.Target.transform;
            _enemyObject = GameObject.Instantiate(_prefab, position, Quaternion.identity);
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

        protected virtual void HitCheck()
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
                        Data.Instance.Character._characterBehaviour.SetArmor(_damage);
                        Data.Instance.Character._characterBehaviour.SetDamage(this);
                    }
                    else if (colliders[i].CompareTag(TagManager.GetTag(TagType.Block)))
                    {
                        Data.Instance.Character._characterBehaviour.SetDamage(_damage);        
                    }
                }

            }
        }

        protected virtual void GetTarget()
        {    
            _target = GameObject.FindWithTag(TagManager.GetTag(TagType.Target)).transform;
        }

        protected virtual void GetDamage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            if (_levelService.ActiveEnemies.Contains(this))
                _levelService.ActiveEnemies.Remove(this);
            Object.Destroy(_enemyObject);
            Wallet.PutLocalCoins(_killReward);
            if (_levelService.ActiveEnemies.Count == 0 && Services.Instance.LevelService.IsLevelSpawnEnded)
            {
                _levelService.EndLevel();
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
