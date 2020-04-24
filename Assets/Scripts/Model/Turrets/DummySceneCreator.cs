using ExampleTemplate;
using UnityEngine;

namespace Snake_box
{
    public class DummySceneCreator : MonoBehaviour
    {
        #region Fields
        
        private bool _initLocker = true; 

        #endregion


        #region UnityMethods

        private void Update()
        {
            if (_initLocker)
            {
                TurretController tc = TurretController.GetInstance();
                TurretBaseAbs newTurret = tc.AddNewTurret();

                newTurret.SetEnemies(Object.FindObjectsOfType<DummyEnemy>());
                newTurret.SetParentTransform(GameObject.Find("TurretPlace1").transform);

                newTurret = tc.AddNewTurret();

                newTurret.SetEnemies(Object.FindObjectsOfType<DummyEnemy>());
                newTurret.SetParentTransform(GameObject.Find("TurretPlace2").transform);

                _initLocker = false;
            }
        }

        #endregion
    }
}
