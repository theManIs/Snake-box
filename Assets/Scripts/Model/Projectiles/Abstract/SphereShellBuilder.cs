using UnityEngine;

namespace Snake_box
{
    public class SphereShellBuilder : ProjectileBuilderAbs
    {
        #region ProjectileBuilderAbs

        protected override TurretProjectileAbs ProjectileInstance => new SphereProjectile();

        public override void Build(Transform firePoint, IEnemy enemy) => BaseBuild(firePoint, enemy);

        #endregion
    }
}