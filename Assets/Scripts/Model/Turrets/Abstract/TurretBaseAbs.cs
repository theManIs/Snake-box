using UnityEngine;

namespace Snake_box
{
    public abstract class TurretBaseAbs : IExecute
    {
        #region Methods

        public abstract void Execute();
        public abstract void SetParentTransform(Transform transform);

        public abstract TurretBaseAbs Build(TurretPreferences turretPreferences);

        #endregion
    }
}