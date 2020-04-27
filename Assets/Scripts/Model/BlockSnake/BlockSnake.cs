using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    public sealed class BlockSnake : MonoBehaviour
    {
        #region Fields
       
        private TurretController _turretController;
        private BlockSnakeData _blockSnakeData;
        private bool _turret;


        #endregion


        #region Unity Method

        private void Awake() 
        {             
            _blockSnakeData = Data.Instance.BlockSnake;           
        }

        #endregion


        #region Method

        public void AddTurret()
        {
            _turretController = TurretController.GetInstance();
            TurretBaseAbs newTurret = _turretController.AddNewTurret();
            newTurret.SetParentTransform(gameObject.transform);   
            _turret = true;
        }

        #endregion
    }
}
