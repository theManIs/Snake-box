using UnityEngine;

namespace Snake_box
{
    public abstract class ProjectileBuilderAbs
    {
        protected ProjectilePreferences ProjectilePreferences;

        #region Methods

        public abstract void Build(Transform firePoint, IEnemy enemy);
        public abstract void BuildMulti(Transform firePoint, IEnemy enemy, int pack);

        public ProjectileBuilderAbs SetProjectilePreferences(ProjectilePreferences projectilePreferences)
        {
            ProjectilePreferences = projectilePreferences;

            return this;
        }

        #endregion
    }
}