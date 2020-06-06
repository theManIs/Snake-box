using UnityEngine;

namespace Snake_box
{
    public class ShotgunShellBuilder : ProjectileBuilderAbs
    {
        #region ProjectileBuilderAbs

        public override void Build(Transform firePoint, IEnemy enemy)
        {
            for (int i = 0; i < ProjectilePreferences.NumberOfPeaces; i++)
                BaseBuild(firePoint, enemy);
        } 

        #endregion

    }
}