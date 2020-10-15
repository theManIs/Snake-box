using UnityEngine;

namespace Snake_box
{
    public class ShotgunShellBuilder : ProjectileBuilderAbs
    {
        #region ProjectileBuilderAbs

        protected override TurretProjectileAbs ProjectileInstance => new ShotgunProjectile();

        public override void Build(Transform firePoint, IEnemy enemy)
        {
            GameObject lastPiece = null;

            for (int i = 0; i < ProjectilePreferences.NumberOfPeaces; i++)
                lastPiece = BaseBuildWithoutShootingImpact(firePoint, enemy);

            if (lastPiece != null)
            {
                ShootingImpact(ProjectilePreferences.ShootingVfxPrefab, lastPiece.transform);
            }
        } 

        #endregion

    }
}