using UnityEngine;

namespace Snake_box
{
    public abstract class ProjectileBuilderAbs
    {
        protected ProjectilePreferences ProjectilePreferences;
        protected static TurretProjectileController _turretProjectileController;
        public static void SetTurretProjectileController(TurretProjectileController tpc) => _turretProjectileController = tpc; 

        #region Methods

        protected void BaseBuild(Transform firePoint, IEnemy enemy)
        {
            GameObject prefabObject = Object.Instantiate(ProjectilePreferences.ProjectilePrefab, Vector3.zero, ProjectilePreferences.ProjectilePrefab.transform.rotation);
            TurretProjectile turretProjectile = new TurretProjectile();

            turretProjectile.SetGameObject(prefabObject);
            turretProjectile.SetProjectilePreferences(ProjectilePreferences);
            turretProjectile.SetFirePoint(firePoint);
            turretProjectile.SetTarget(enemy);
            turretProjectile.SetLookRotation(enemy.GetTransform());
            turretProjectile.SetSelfDestruct(1);
            turretProjectile.CountDistance();

            _turretProjectileController.AddShell(turretProjectile);
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