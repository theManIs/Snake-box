using System;
using Assets.Scripts.Model.Turrets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Snake_box
{
    public sealed class CannonShellBuilder : ProjectileBuilderAbs
    {
        #region Fields

//        private static readonly GameObject TurretShellPrefab = Resources.Load<GameObject>("Prefabs/Turrets/TurretFireball");
        private static readonly GameObject TurretShellPrefab = Resources.Load<GameObject>("Prefabs/Turrets/Bullet/Prefabs/Bullet762");
        private static TurretProjectileController _turretProjectileController; 

        #endregion


        #region Methods

        public static void SetTurretProjectileController(TurretProjectileController tpc) => _turretProjectileController = tpc; 

        #endregion


        #region ProjectileBuilderAbs

        public override void Build(Transform firePoint, IEnemy enemy)
        {
            GameObject prefabObject = Object.Instantiate(TurretShellPrefab, Vector3.zero, TurretShellPrefab.transform.rotation);
            TurretProjectile turretProjectile = new TurretProjectile();

            turretProjectile.SetGameObject(prefabObject);
            turretProjectile.SetFirePoint(firePoint);
            turretProjectile.SetTarget(enemy);
            turretProjectile.SetSelfDestruct(5);
            turretProjectile.CountDistance();

            _turretProjectileController.AddShell(turretProjectile);
        } 

        #endregion
    }
}