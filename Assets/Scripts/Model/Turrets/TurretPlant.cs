using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
    public sealed class TurretPlant
    {
        #region Fields

        private TurretData _turretData;

        #endregion


        #region ClassLifeCycle

        public TurretPlant(TurretData turretData) => _turretData = turretData;

        #endregion


        #region Methods

        public TurretBaseAbs AddCannonTurret() => AddAndReturn(typeof(CannonTurret));

        public TurretBaseAbs AddMachineGunTurret() => AddAndReturn(typeof(MachineGunTurret));

        public TurretBaseAbs AddFrostGunTurret() => AddAndReturn(typeof(FrostGunTurret));

        public TurretBaseAbs AddLaserTurret() => AddAndReturn(typeof(LaserTurret));

        public TurretBaseAbs AddPlasmaTurret() => AddAndReturn(typeof(PlasmaTurret));

        public TurretBaseAbs AddShotgunTurret() => AddAndReturn(typeof(ShotgunTurret));

        public TurretBaseAbs AddFrostShotgunTurret() => AddAndReturn(typeof(FrostShotgunTurret));

        public TurretBaseAbs AddAirWaveTurret() => AddAndReturn(typeof(AirWaveTurret));
        public TurretBaseAbs AddPlasmaRailTurret() => AddAndReturn(typeof(PlasmaRailTurret));

        public void ChangeTurretType(KeyCode keyCode)
        {
            List<TurretBaseAbs> localList = new List<TurretBaseAbs>(_turretData.TurretList);
            Dictionary<KeyCode, Type> buttonsDictionary = new Dictionary<KeyCode, Type>
            {
                { KeyCode.F, typeof(FrostShotgunTurret) },
                { KeyCode.C, typeof(CannonTurret) },
                { KeyCode.V, typeof(LaserTurret) },
                { KeyCode.G, typeof(ShotgunTurret) },
            };

            if (localList.Count > 0)
            {
                List<TurretBaseAbs> turretBaseAbs = new List<TurretBaseAbs>();

                foreach (TurretBaseAbs tba in localList)
                {
                    TurretBaseAbs turret2 = Data.Instance.TurretData.TurretPlant.AddAndReturn(buttonsDictionary[keyCode]);

                    tba.ReplaceTurret(turret2);
                    turretBaseAbs.Add(turret2);
                }

                _turretData.TurretList = turretBaseAbs;
            }
        }

        private TurretBaseAbs AddAndReturn(Type turretType)
        {
            TurretBaseAbs newTurret;

            if (turretType == typeof(MachineGunTurret))
                newTurret = new MachineGunTurret().Build(_turretData.MachineGunTurret);
            else if (turretType == typeof(FrostGunTurret))
                newTurret = new FrostGunTurret().Build(_turretData.FrostGunTurret);
            else if (turretType == typeof(LaserTurret))
                newTurret = new LaserTurret().Build(_turretData.LaserTurret);
            else if (turretType == typeof(PlasmaTurret))
                newTurret = new PlasmaTurret().Build(_turretData.PlasmaTurret);
            else if (turretType == typeof(ShotgunTurret))
                newTurret = new ShotgunTurret().Build(_turretData.ShotgunTurret);
            else if (turretType == typeof(FrostShotgunTurret))
                newTurret = new FrostShotgunTurret().Build(_turretData.FrostShotgunTurret);
            else if (turretType == typeof(AirWaveTurret))
                newTurret = new AirWaveTurret().Build(_turretData.AirWaveTurret);
            else if (turretType == typeof(PlasmaRailTurret))
                newTurret = new PlasmaRailTurret().Build(_turretData.PlasmaRailTurret);
            else
                newTurret = new CannonTurret().Build(_turretData.CannonTurret);

            _turretData.TurretList.Add(newTurret);

            return newTurret;
        }

        #endregion
    }
}