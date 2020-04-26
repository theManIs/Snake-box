using ExampleTemplate;
using UnityEngine;

namespace Snake_box
{
    public abstract class TurretBaseAbs : IExecute
    {
        #region Methods

        public abstract void Execute();
        public abstract void SetEnemies(IDummyEnemy[] findObjectsOfType);
        public abstract void SetParentTransform(Transform transform); 

        #endregion
    }
}