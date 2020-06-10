using UnityEngine;

namespace Snake_box
{
    public abstract class ProjectileBuilderAbs
    {
        protected ProjectilePreferences ProjectilePreferences;
        protected static TurretProjectileController _turretProjectileController;
        public static void SetTurretProjectileController(TurretProjectileController tpc) => _turretProjectileController = tpc; 

        #region Methods

        protected virtual TurretProjectileAbs ProjectileInstance => new CannonProjectile();

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

            _turretProjectileController.AddShell(cannonProjectile);
        }

        public abstract void Build(Transform firePoint, IEnemy enemy);

        public ProjectileBuilderAbs SetProjectilePreferences(ProjectilePreferences projectilePreferences)
        {
            ProjectilePreferences = projectilePreferences;

            return this;
        }

        #endregion
    }
}