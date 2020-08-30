using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Snake_box
{
    public sealed class TurretController : IExecute, IInitialization
    {
        #region Fields

        private static TurretController _hiddenInstance;
        private TurretInitializer _newTurret;
        private List<TurretBaseAbs> _turretList = new List<TurretBaseAbs>();
        private int _pressFrameLock = 0;
        private int _pressFrameLockInit = 25;

        #endregion


        #region IInitializaion

        public void Initialization()
        {
            _hiddenInstance = this;
        }

        #endregion


        #region Execute

        public void Execute()
        {
            SetTurretList();

            _turretList = _turretList.Where(x => x != null ? true : false).ToList();

            _turretList.ForEach(iExecutable => iExecutable.Execute());

            if ((Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.V) || Input.GetKey(KeyCode.G)) && _pressFrameLock <= 0)
            {
                ChangeTurretType();

                _pressFrameLock = _pressFrameLockInit;
//                Debug.Log("Multipress");
            }

            _pressFrameLock--;
        }

        #endregion


        #region Methods

        private void SetTurretList() => _turretList = Data.Instance.TurretData.GetTurretList();

        private void ChangeTurretType()
        {
            TurretBaseAbs turret2 = null;

            if (_turretList.Count > 0)
            {
                List<TurretBaseAbs> turretBaseAbs = new List<TurretBaseAbs>();

                Debug.Log(_turretList.Count);

                foreach (TurretBaseAbs tba in _turretList)
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        turret2 = Data.Instance.TurretData.TurretPlant.AddFrostTurret();
                    } 
                    else if (Input.GetKey(KeyCode.C))
                    {
                        turret2 = Data.Instance.TurretData.TurretPlant.AddCannonTurret();
                    } 
                    else if (Input.GetKey(KeyCode.V))
                    {
                        turret2 = Data.Instance.TurretData.TurretPlant.AddLaserTurret();
                    } 
                    else if (Input.GetKey(KeyCode.G))
                    {
                        turret2 = Data.Instance.TurretData.TurretPlant.AddShotgunTurret();
                    }

                    Transform transform = tba.GetParentTransform();
                    turret2.SetParentTransform(transform);
                    turretBaseAbs.Add(turret2);
                    tba.ReleaseTurret();
                }

                _turretList = turretBaseAbs;
                Data.Instance.TurretData.TurretList = _turretList;
            }
        }

        #endregion
    }
}