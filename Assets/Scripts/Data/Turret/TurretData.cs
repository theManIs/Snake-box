using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    [CreateAssetMenu(fileName = nameof(TurretData), menuName = "Data/Turret/" + nameof(TurretData))]
    public class TurretData : ScriptableObject
    {
        #region Fields

        public TurretPreferences CannonTurret = new TurretPreferences();
        public TurretPreferences ShotgunTurret = new TurretPreferences();
        public TurretPreferences MachineGunTurret = new TurretPreferences();
        public TurretPreferences FrostTurret = new TurretPreferences();
        public TurretPreferences FrostGunTurret = new TurretPreferences();
        public TurretPreferences FreezerTurret = new TurretPreferences();
        public TurretPreferences PlasmaTurret = new TurretPreferences();
        public TurretPreferences LaserTurret = new TurretPreferences();
        public TurretPreferences PlasmaRailTurret = new TurretPreferences();
        public TurretPreferences GrenadeTurret = new TurretPreferences();
        public TurretPreferences IncendiaryTurret = new TurretPreferences();
        public TurretPreferences RocketTurret = new TurretPreferences();
        public TurretPreferences AirTurret = new TurretPreferences();
        public TurretPreferences AirTunnelTurret = new TurretPreferences();
        public TurretPreferences AirWaveTurret = new TurretPreferences();

        public List<TurretBaseAbs> TurretList = new List<TurretBaseAbs>();
        public TurretPlant TurretPlant;

        #endregion

        #region ClassLifeCycle

        public TurretData() => TurretPlant = new TurretPlant(this); 

        #endregion


        #region Methods

        /// <summary>
        /// deprecated
        /// </summary>
        /// <returns></returns>
        public TurretBaseAbs AddNewTurret()
        {
            Debug.Log("AddNewTurret");
            TurretBaseAbs newTurret = TurretPlant.AddCannonTurret();

//            TurretList.Add(newTurret);

            return newTurret;
        }

        /// <summary>
        /// deprecated
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public TurretBaseAbs AddNewWithParent(Transform parent)
        {
            TurretBaseAbs newTurret = AddNewTurret();

            newTurret.SetParentTransform(parent);

            return newTurret;
        }

        public List<TurretBaseAbs> GetTurretList() => TurretList;

        public void ClearTurretList() => TurretList.Clear();

        #endregion
    }
}