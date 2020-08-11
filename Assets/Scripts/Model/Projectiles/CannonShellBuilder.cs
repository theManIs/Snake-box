using UnityEngine;
using Object = UnityEngine.Object;

namespace Snake_box
{
    public sealed class CannonShellBuilder : ProjectileBuilderAbs
    {

        #region ProjectileBuilderAbs

        public override void Build(Transform firePoint, IEnemy enemy) => BaseBuild(firePoint, enemy);

        #endregion
    }
}