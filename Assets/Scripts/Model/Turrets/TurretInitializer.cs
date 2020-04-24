using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Controllers;
using ExampleTemplate;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Assets.Scripts.Model.Turrets
{
    public sealed class TurretInitializer : IExecute, IInitialization
    {
        #region Fields

        public TurretBehaviour TurretSprite;
        public string TurretSpritePath = "Prefabs/Turrets/DummyTurret";
        public string TurretFireballPath = "Prefabs/Turrets/TurretFireball";
        private IDummyEnemy[] _dummyEnemies = new IDummyEnemy[3];
        public float TurretRange = 6;
        public GameObject TurretInstance;
        public GameObject ProjectileInstance;
        public ArmorTypes PreferredArmorType = ArmorTypes.Heavy;
        public float Cooldown = 250;
        private float _frameRateLock = 0;
        private Quaternion _haltTurretRotation;

        #endregion


        #region ClassLifeCycle

        public TurretInitializer()
        {
            Initialization();
        } 

        #endregion


        #region Methods

        public void SetEnemies(IDummyEnemy[] dummyEnemies) => _dummyEnemies = dummyEnemies;


        public void SetParentTransform(Transform parentTransform)
        {
            TurretInstance.transform.parent = parentTransform;
            TurretInstance.transform.localPosition = Vector3.zero;
        }

        public void ContinueShooting()
        {
            if (Time.frameCount - _frameRateLock > Cooldown)
            {
                IDummyEnemy nearestEnemy = NearestEnemy();

                if (nearestEnemy == null)
                    return;

                TurretProjectileController.SpawnRegularBullet(TurretSprite.FirePoint, nearestEnemy.GetTransform()); //todo Replace
//                GameObject newProjectile = Object.Instantiate(ProjectileInstance, TurretSprite.FirePoint.position, TurretInstance.transform.rotation);

//                Rigidbody2D rb2d = newProjectile.AddComponent<Rigidbody2D>();
//                rb2d.isKinematic = true;
//                rb2d.velocity = TurretInstance.transform.right * 15;

                _frameRateLock = Time.frameCount;

//                Object.Destroy(newProjectile, 5);
            }
        }

        public void LockTarget()
        {
            IDummyEnemy nearestEnemy = NearestEnemy();

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

        private void CollectKilledEnemies()
        {
            _dummyEnemies = _dummyEnemies.Where((element) => !element.AmIDestroyed()).ToArray();
        }

        private IDummyEnemy NearestEnemy()
        {
            CollectKilledEnemies();

            if (_dummyEnemies.Length < 1)
                return null;

            IDummyEnemy nearestEnemy = null;
            float closestDistance = TurretRange;
            ArmorTypes enemyArmorType = ArmorTypes.None;

            foreach (IDummyEnemy enemy in _dummyEnemies)
            {
                float checkingDistance = Vector3.Distance(
                    enemy.GetPosition(),
                    TurretInstance.transform.position);

                if (checkingDistance > TurretRange)
                {
                    continue;
                }
                else if (enemyArmorType == PreferredArmorType 
                         && enemy.GetArmorType() != PreferredArmorType 
                         && PreferredArmorType != ArmorTypes.None)
                {
                    continue;
                }
                
                if (checkingDistance < closestDistance || enemyArmorType != PreferredArmorType && enemy.GetArmorType() == PreferredArmorType)
                {
                    closestDistance = checkingDistance;
                    nearestEnemy = enemy;
                    enemyArmorType = enemy.GetArmorType();
                }
            }

            return nearestEnemy;
        }

        private void HaltTurret()
        {
            IDummyEnemy nearestEnemy = NearestEnemy();

            if (nearestEnemy == null)
                TurretInstance.transform.rotation = _haltTurretRotation;
        }

        public void AddEnemy(IDummyEnemy newDummyEnemy)
        {
            List<IDummyEnemy> temporaryList = _dummyEnemies.ToList();

            temporaryList.Add(newDummyEnemy);

            _dummyEnemies = temporaryList.ToArray();
        }

        public void RemoveEnemy(IDummyEnemy newDummyEnemy)
        {
            CollectKilledEnemies();

            List<IDummyEnemy> temporaryList = _dummyEnemies.ToList();

            temporaryList.Remove(newDummyEnemy);

            _dummyEnemies = temporaryList.ToArray();
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            TurretSprite = Resources.Load<TurretBehaviour>(TurretSpritePath);
            ProjectileInstance = Resources.Load<GameObject>(TurretFireballPath);
            TurretInstance = Object.Instantiate(TurretSprite.gameObject, Vector3.zero, Quaternion.identity);
            TurretSprite = TurretInstance.GetComponent<TurretBehaviour>();
            _haltTurretRotation = TurretInstance.transform.rotation;
        }


        #endregion


        #region IExecute

        public void Execute()
        {
            LockTarget();
            ContinueShooting();
            HaltTurret();
        } 

        #endregion
    }
}
