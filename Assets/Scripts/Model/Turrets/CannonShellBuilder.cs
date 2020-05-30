using UnityEngine;
using Object = UnityEngine.Object;

namespace Snake_box
{
    public sealed class CannonShellBuilder : ProjectileBuilderAbs
    {
        #region Fields

//        private static readonly GameObject TurretShellPrefab = Resources.Load<GameObject>("Prefabs/Turrets/Bullet/Prefabs/Bullet762");
        private static TurretProjectileController _turretProjectileController;

        #endregion


        #region Methods

        public static void SetTurretProjectileController(TurretProjectileController tpc) => _turretProjectileController = tpc; 

        #endregion


        #region ProjectileBuilderAbs

        public override void Build(Transform firePoint, IEnemy enemy)
        {
            GameObject prefabObject = Object.Instantiate(ProjectilePreferences.ProjectilePrefab, Vector3.zero, ProjectilePreferences.ProjectilePrefab.transform.rotation);
            TurretProjectile turretProjectile = new TurretProjectile();

            turretProjectile.SetGameObject(prefabObject);
            turretProjectile.SetProjectilePreferences(ProjectilePreferences);
            turretProjectile.SetFirePoint(firePoint);
            turretProjectile.SetTarget(enemy);
            turretProjectile.SetLookRotation(enemy.GetTransform());
            turretProjectile.SetSelfDestruct(5);
            turretProjectile.CountDistance();

            _turretProjectileController.AddShell(turretProjectile);
        } 

        #endregion
    }
}