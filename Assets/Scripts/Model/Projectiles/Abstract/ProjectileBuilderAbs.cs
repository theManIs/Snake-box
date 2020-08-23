using UnityEngine;

namespace Snake_box
{
    public abstract class ProjectileBuilderAbs
    {
        #region Fields

        protected int AbilityLevel = 1;
        protected float TurretDistanceMod = 1;
        protected float ProjectileDamageMod = 1;

        protected ProjectilePreferences ProjectilePreferences;
        protected static TurretProjectileController _turretProjectileController;

        #endregion


        #region Properties

        public static void SetTurretProjectileController(TurretProjectileController tpc) => _turretProjectileController = tpc;

        #endregion


        #region Methods

        protected virtual TurretProjectileAbs ProjectileInstance => new CannonProjectile();

        public abstract void Build(Transform firePoint, IEnemy enemy);

        protected void BaseBuild(Transform firePoint, IEnemy enemy)
        {
            GameObject prefabObject = Object.Instantiate(ProjectilePreferences.ProjectilePrefab, Vector3.zero, ProjectilePreferences.ProjectilePrefab.transform.rotation);
            TurretProjectileAbs cannonProjectile = ProjectileInstance;

            cannonProjectile.SetGameObject(prefabObject);
            cannonProjectile.SetProjectilePreferences(ProjectilePreferences);
            cannonProjectile.SetFirePoint(firePoint);
            cannonProjectile.SetTarget(enemy);
            cannonProjectile.SetLookRotation(enemy.GetTransform());
            cannonProjectile.SetSelfDestruct(ProjectilePreferences.SelfDestructAfter);
            cannonProjectile.CountDistance();
            cannonProjectile.SetAbilityLevel(AbilityLevel);
            cannonProjectile.SetProjectileDamageMod(ProjectileDamageMod);

            _turretProjectileController.AddShell(cannonProjectile);
        }

        public ProjectileBuilderAbs SetProjectilePreferences(ProjectilePreferences projectilePreferences)
        {
            ProjectilePreferences = projectilePreferences;

            return this;
        }

        public ProjectileBuilderAbs SetDamageAndAbility(float newTurretDistanceMod, int newAbilityLevel, float newProjectileDamageMod)
        {
            AbilityLevel = newAbilityLevel;
            TurretDistanceMod = newTurretDistanceMod;
            ProjectileDamageMod = newProjectileDamageMod; 

            return this;
        }

        #endregion
    }
}