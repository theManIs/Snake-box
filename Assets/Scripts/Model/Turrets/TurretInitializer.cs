using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Model.Turrets;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Snake_box
{
    public sealed class TurretInitializer : TurretBaseAbs, IInitialization
    {
        #region Fields

        public GameObject TurretInstance;
        private Quaternion _haltTurretRotation;
        public string TurretSpritePath = "Prefabs/Turrets/DummyTurret";
        public float TurretRange = 6;
        public float Cooldown = 250;
        //todo use TimeRemaining
        private float _frameRateLock = 0;

        public EnemyType PreferredArmorType = EnemyType.None;
        private List<IEnemy> _dummyEnemies = new List<IEnemy>();
        public TurretBehaviour TurretBehaviour;

        #endregion


        #region ClassLifeCycle

        public TurretInitializer()
        {
            Initialization();
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            //todo move that to turret builder
            TurretBehaviour = Resources.Load<TurretBehaviour>(TurretSpritePath);
            TurretInstance = Object.Instantiate(TurretBehaviour.gameObject, Vector3.zero, Quaternion.identity);
            _haltTurretRotation = TurretInstance.transform.rotation;
            TurretBehaviour = TurretInstance.GetComponent<TurretBehaviour>();
        }


        #endregion


        #region TurretBaseAbs

        public override void SetParentTransform(Transform parentTransform)
        {
            TurretInstance.transform.parent = parentTransform;
            TurretInstance.transform.localPosition = Vector3.zero;
        }
        public override void Execute()
        {
            RecoilEnemies();
            LockTarget();
            ContinueShooting();
            HaltTurret();
        }

        #endregion


        #region Methods

        public void ContinueShooting()
        {
            if (Time.frameCount - _frameRateLock > Cooldown)
            {
                IEnemy nearestEnemy = NearestEnemy();

                if (nearestEnemy == null)
                    return;

                GetProjectile().Build(TurretBehaviour.FirePoint, nearestEnemy.GetTransform());

                _frameRateLock = Time.frameCount;
            }
        }

        private ProjectileBuilderAbs GetProjectile() => new CannonShellBuilder();

        public void LockTarget()
        {
            IEnemy nearestEnemy = NearestEnemy();

            if (nearestEnemy == null)
                return;

            Vector3 direction3d = nearestEnemy.GetPosition() - TurretInstance.transform.position;
            float angle = Mathf.Atan2(direction3d.y, direction3d.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            TurretInstance.transform.rotation = Quaternion.Slerp(TurretInstance.transform.rotation, rotation, 1);
        }

        public void TakeAim()
        {
            Vector2 direction2d =
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - TurretInstance.transform.position;

            float angle = Mathf.Atan2(direction2d.y, direction2d.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            TurretInstance.transform.rotation = Quaternion.Slerp(TurretInstance.transform.rotation, rotation, 1);
        }

        private void CollectKilledEnemies() => _dummyEnemies = _dummyEnemies.Where((element) => !element.AmIDestroyed()).ToList();

        private IEnemy NearestEnemy()
        {
            CollectKilledEnemies();

            if (_dummyEnemies.Count < 1)
                return null;

            IEnemy nearestEnemy = null;
            float closestDistance = TurretRange;
            EnemyType enemyArmorType = EnemyType.None;

            foreach (IEnemy enemy in _dummyEnemies)
            {
                float checkingDistance = Vector3.Distance(
                    enemy.GetPosition(),
                    TurretInstance.transform.position);

                if (checkingDistance > TurretRange)
                {
                    continue;
                }
                else if (enemyArmorType == PreferredArmorType 
                         && enemy.GetEnemyType() != PreferredArmorType 
                         && PreferredArmorType != EnemyType.None)
                {
                    continue;
                }
                
                if (checkingDistance < closestDistance || enemyArmorType != PreferredArmorType && enemy.GetEnemyType() == PreferredArmorType)
                {
                    closestDistance = checkingDistance;
                    nearestEnemy = enemy;
                    enemyArmorType = enemy.GetEnemyType();
                }
            }

            return nearestEnemy;
        }

        private void HaltTurret()
        {
            IEnemy nearestEnemy = NearestEnemy();

            if (nearestEnemy == null)
                TurretInstance.transform.rotation = _haltTurretRotation;
        }

        public void AddEnemy(IEnemy newDummyEnemy) => _dummyEnemies.Add(newDummyEnemy);

        public void RemoveEnemy(IEnemy newDummyEnemy) => _dummyEnemies.Remove(newDummyEnemy);

        private void RecoilEnemies() => _dummyEnemies = Services.Instance.LevelService.ActiveEnemies;

        #endregion
    }
}
