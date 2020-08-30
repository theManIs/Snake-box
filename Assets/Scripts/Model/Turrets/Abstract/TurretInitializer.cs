using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;


namespace Snake_box
{
    public class TurretInitializer : TurretBaseAbs, IInitialization
    {
        #region Fields

        //todo make it private
        public GameObject TurretInstance;
        //todo remove sprite path
        public string TurretSpritePath = "Prefabs/Turrets/Turret3D";

        protected TurretPreferences TurretPreferences;
        protected Transform FirePoint;

        private List<IEnemy> _dummyEnemies = new List<IEnemy>();
        private Quaternion _haltTurretRotation;
        //todo use TimeRemaining
        private float _frameRateLock = 0;

        #endregion


        #region Properties

        public float Cooldown => TurretPreferences.Cooldown * FireRateMod;
        public float TurretRange => TurretPreferences.Range * TurretDistanceMod;
        public GameObject TurretPrefab => TurretPreferences.TurretPrefab;
        public EnemyType PreferredArmorType => TurretPreferences.PreferableEnemy;
        public float BuyCost => TurretPreferences.BuyPrice * DecreaseBuyCost;
        public float UpdateCost => TurretPreferences.UpdatePrice * DecreaseUpgradeCost;

        #endregion


        #region IInitialization

        public void Initialization()
        {
            GameObject turretResource =  TurretPreferences != null && TurretPrefab != null ? TurretPrefab : Resources.Load<GameObject>(TurretSpritePath);
            TurretInstance = Object.Instantiate(turretResource, Vector3.zero, turretResource.transform.rotation);
            _haltTurretRotation = TurretInstance.transform.rotation;
            FirePoint = TurretPreferences != null ? TurretInstance.transform.Find(TurretPreferences.FirePointHierarchy) : TurretInstance.transform;
        }


        #endregion


        #region TurretBaseAbs

        public override void SetParentTransform(Transform parentTransform)
        {
            TurretInstance.transform.parent = parentTransform;
            TurretInstance.transform.localPosition = Vector3.zero;
        }

        public override void ReleaseTurret()
        {
            //            TurretInstance.SetActive(false);
            _isDeleted = true;

            TurretInstance.SetActive(false);
            Object.Destroy(TurretInstance, 5);
        }

        public override void ReplaceTurret(TurretBaseAbs newOne)
        {
            newOne.SetParentTransform(GetParentTransform());
            ReleaseTurret();
        }

        private bool _isDeleted = false;

        public override Transform GetParentTransform()
        {
            return TurretInstance.transform.parent;
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
            if (_isDeleted)
            {
                return;
            }

            if (Time.frameCount - _frameRateLock > Cooldown)
            {
                IEnemy nearestEnemy = NearestEnemy();

                if (nearestEnemy == null)
                    return;

                GetProjectile().Build(FirePoint, nearestEnemy);

                _frameRateLock = Time.frameCount + Mathf.Round(Random.value * 10);
            }
        }

        protected virtual ProjectileBuilderAbs GetProjectile() =>
            new CannonShellBuilder().SetProjectilePreferences(TurretPreferences.ProjectilePreferences)
                .SetDamageAndAbility(TurretDistanceMod, AbilityLevel, ProjectileDamageMod);

        private Quaternion RotateAroundAxis(Vector3 pointA, Vector3 pointB, Quaternion startRotation)
        {
            Vector3 direction3d = pointA - pointB;
            float angle = Mathf.Atan2(direction3d.z, direction3d.x) * Mathf.Rad2Deg;
            Quaternion rotateAround = Quaternion.AngleAxis(angle, Vector3.forward);

            Quaternion rotation = Quaternion.Euler(rotateAround.eulerAngles);
            Debug.Log(rotateAround.eulerAngles);

            return rotation;
        }

        public void LockTarget()
        {

            if (_isDeleted)
            {
                return;
            }

            IEnemy nearestEnemy = NearestEnemy();

            if (nearestEnemy == null)
                return;

            Vector3 lookAngles = Quaternion.LookRotation(nearestEnemy.GetPosition() - TurretInstance.transform.position).eulerAngles;
            lookAngles.x = _haltTurretRotation.eulerAngles.x;
            lookAngles.z = _haltTurretRotation.eulerAngles.z;
            lookAngles.y = lookAngles.y + _haltTurretRotation.eulerAngles.y;

            TurretInstance.transform.rotation = Quaternion.Euler(lookAngles);
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

            if (_isDeleted)
            {
                return;
            }

            IEnemy nearestEnemy = NearestEnemy();

            if (nearestEnemy == null)
                TurretInstance.transform.rotation = _haltTurretRotation;
        }

        public void AddEnemy(IEnemy newDummyEnemy) => _dummyEnemies.Add(newDummyEnemy);

        public void RemoveEnemy(IEnemy newDummyEnemy) => _dummyEnemies.Remove(newDummyEnemy);

        private void RecoilEnemies() => _dummyEnemies = Services.Instance.LevelService.ActiveEnemies;

        public override TurretBaseAbs Build(TurretPreferences turretPreferences)
        {
            TurretPreferences = turretPreferences;

            Initialization();

            return this;
        }

        #endregion
    }
}
