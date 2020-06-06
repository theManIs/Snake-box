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
                TurretPlant localPlant = Data.Instance.TurretData.TurretPlant;
                //                localPlant.AddPlasmaTurret().SetParentTransform(GameObject.Find("TurretPlace1").transform);
//                localPlant.AddFrostGunTurret().SetParentTransform(GameObject.Find("TurretPlace2").transform);
                localPlant.AddShotgunTurret().SetParentTransform(GameObject.Find("TurretPlace1").transform);
//                localPlant.AddLaserTurret().SetParentTransform(GameObject.Find("TurretPlace2").transform);
//                localPlant.AddCannonTurret().SetParentTransform(GameObject.Find("TurretPlace1").transform);

                Services.Instance.LevelService.ActiveEnemies = new List<IEnemy>(Object.FindObjectsOfType<DummyEnemy>());
                _initLocker = false;
            }
        }

        #endregion
    }
}
