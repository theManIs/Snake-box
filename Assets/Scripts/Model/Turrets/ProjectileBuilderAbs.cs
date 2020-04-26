using UnityEngine;

namespace Snake_box
{
    public abstract class ProjectileBuilderAbs
    {
        #region Methods

        public abstract void Build(Transform firePoint, Transform enemy); 

        #endregion
    }
}