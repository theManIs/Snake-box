using UnityEngine;


namespace Snake_box
{
    public class BonusBullet
    {

        #region Fields  

        private ITimeService _timeService;
        private Transform _prefab = Data.Instance.TurretData.CannonTurret.ProjectilePreferences.ProjectilePrefab.transform;
        private Transform _bullet;
        private int _damage = 1000;///если будет использоваться то нужно будет сделать данные из скриптблОБЖ
        private int _speed = 20;
        private TimeRemaining _lifeTimer;
        private float _lifeTime=8;

        #endregion


        #region Methods

        public BonusBullet()
        {           
            _lifeTimer = new TimeRemaining(LifeTimer, _lifeTime);
        }

        public void Move()
        {
            _timeService = Services.Instance.TimeService;
            _bullet.position +=  _speed* _bullet.forward * _timeService.DeltaTime();
            Collider[] _collidedObjects = new Collider[30];
            var tagCollider = Physics.OverlapSphereNonAlloc(_bullet.transform.position, 3, _collidedObjects);
            for (int i = 0; i < tagCollider; i++)
            {
                if (_collidedObjects[i].CompareTag(TagManager.GetTag(TagType.Enemy)))
                {                    
                    for (int b = 0; b < Services.Instance.LevelService.ActiveEnemies.Count; b++)
                    {
                        if (Services.Instance.LevelService.ActiveEnemies[b].GetTransform() == _collidedObjects[i].transform)
                        {
                            if (Services.Instance.LevelService.ActiveEnemies[b] is IDamageAddressee ActiveEnemy)
                            {
                                ActiveEnemy.RegisterDamage(_damage, ArmorTypes.None);
                            }                                
                        }
                    }
                }
            }
        }

        public void LifeTimer()
        {
            Object.Destroy(_bullet.gameObject);
            Services.Instance.LevelService.ActiveBonusBullet.Remove(this);
        }

        public void Spawn(Transform transform, Quaternion quaternion)
        {
            _bullet = Transform.Instantiate(_prefab, transform.position, quaternion);
            BonusBullet BonusBullet = new BonusBullet();
            BonusBullet = this;
            Services.Instance.LevelService.ActiveBonusBullet.Add(BonusBullet);
            _lifeTimer.AddTimeRemaining();
        }
    }

    #endregion

}
