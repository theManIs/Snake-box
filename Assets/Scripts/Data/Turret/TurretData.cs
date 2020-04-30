using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = nameof(TurretData), menuName = "Data/Turret/" + nameof(TurretData))]
    public class TurretData : ScriptableObject
    {
        #region Fields

        private List<TurretBaseAbs> _turretList = new List<TurretBaseAbs>();

        #endregion


        #region Methods

        public TurretBaseAbs AddNewTurret()
        {
            TurretBaseAbs newTurret = new TurretInitializer();

            _turretList.Add(newTurret);

            return newTurret;
        }

        public TurretBaseAbs AddNewWithParent(Transform parent)
        {
            TurretBaseAbs newTurret = AddNewTurret();

            newTurret.SetParentTransform(parent);

            return newTurret;
        }

        public List<TurretBaseAbs> GetTurretList() => _turretList; 

        #endregion
    }
}