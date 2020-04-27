using System.Collections.Generic;
using System.Linq;
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
                Data.Instance.TurretData.AddNewWithParent(GameObject.Find("TurretPlace1").transform);
                Data.Instance.TurretData.AddNewWithParent(GameObject.Find("TurretPlace2").transform);

                Services.Instance.LevelService.ActiveEnemies = new List<IEnemy>(Object.FindObjectsOfType<DummyEnemy>());
                _initLocker = false;
            }
        }

        #endregion
    }
}
