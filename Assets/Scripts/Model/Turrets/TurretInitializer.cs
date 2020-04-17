using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Model.Turrets
{
    public sealed class TurretInitializer : MonoBehaviour
    {
        #region Fields

        public TurretBehaviour TurretSprite;
        public Vector2 DescartesPosition = Vector2.zero;
        public string TurretSpritePath = "Prefabs/Turrets/DummyTurret";
        public string TurretFireballPath = "Prefabs/Turrets/TurretFireball";
        public DummyEnemy[] DummyEnemies = new DummyEnemy[3];
        public float TurretRange = 5;
        public GameObject TurretInstance;
        public GameObject ProjectileInstance;
        public ArmorTypes PreferredArmorType = ArmorTypes.None;
        public float Cooldown = 250;
        private float _frameRateLock = 0;
        private Quaternion _haltTurretRotation;

        #endregion


        #region MonoBehaviour

        void Awake()
        {
            TurretSprite = Resources.Load<TurretBehaviour>(TurretSpritePath);
            ProjectileInstance = Resources.Load<GameObject>(TurretFireballPath);
            TurretInstance = Instantiate(TurretSprite.gameObject, DescartesPosition, Quaternion.identity);
            TurretSprite = TurretInstance.GetComponent<TurretBehaviour>();
            _haltTurretRotation = TurretInstance.transform.rotation;
        }

        void Update()
        {
//            TakeAim();
            LockTarget();
            ContinueShooting();
            HaltTurret();
        }

        #endregion


        #region Methods

        public void SetParentTransform(Transform parentTransform)
        {
            TurretInstance.transform.parent = parentTransform;
            TurretInstance.transform.position = Vector3.zero;
        }

        public void ContinueShooting()
        {
            if (Time.frameCount - _frameRateLock > Cooldown)
            {
                IDummyEnemy nearestEnemy = NearestEnemy();

                if (nearestEnemy == null)
                    return;

                GameObject newProjectile = Instantiate(ProjectileInstance, TurretSprite.FirePoint.position, TurretInstance.transform.rotation);

                Rigidbody2D rb2d = newProjectile.AddComponent<Rigidbody2D>();
                rb2d.isKinematic = true;
                rb2d.velocity = TurretInstance.transform.right * 15;
                _frameRateLock = Time.frameCount;

                Destroy(newProjectile, 5);
            }
        }

        public void LockTarget()
        {
            IDummyEnemy nearestEnemy = NearestEnemy();

            if (NearestEnemy() == null)
                return;

            Vector2 direction2d = nearestEnemy.GetPosition() - DescartesPosition;
            float angle = Mathf.Atan2(direction2d.y, direction2d.x) * Mathf.Rad2Deg;
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
            DummyEnemies = DummyEnemies.Where((element) => element ? true : false).ToArray();
        }

        private IDummyEnemy NearestEnemy()
        {
            CollectKilledEnemies();

            if (DummyEnemies.Length < 1)
                return null;

            IDummyEnemy nearestEnemy = null;
            float closestDistance = TurretRange;
            ArmorTypes enemyArmorType = ArmorTypes.None;

            foreach (IDummyEnemy enemy in DummyEnemies)
            {
                float checkingDistance = Vector2.Distance(enemy.GetPosition(), DescartesPosition);

                if (checkingDistance > TurretRange)
                {
                    continue;
                }
                else if (enemyArmorType == PreferredArmorType && enemy.GetArmorType() != PreferredArmorType)
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

        #endregion
    }
}
