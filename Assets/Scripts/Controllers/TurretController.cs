using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Model.Turrets;
using ExampleTemplate;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public sealed class TurretController : IExecute, IInitialization
    {
        #region Fields

        private TurretInitializer _newTurret;
        private List<TurretInitializer> _turretList = new List<TurretInitializer>();

        #endregion


        #region IInitializaion

        public void Initialization()
        {
            _newTurret = AddNewTurret();

            _newTurret.SetEnemies(Object.FindObjectsOfType<DummyEnemy>());
            _newTurret.SetParentTransform(GameObject.Find("TurretPlace1").transform);

            _newTurret = AddNewTurret();

            _newTurret.SetEnemies(Object.FindObjectsOfType<DummyEnemy>());
            _newTurret.SetParentTransform(GameObject.Find("TurretPlace2").transform);
        }

        #endregion


        #region Execute

        public void Execute()
        {
            _turretList = _turretList.Where(x => x != null ? true : false).ToList();

            _turretList.ForEach(iExecutable => iExecutable.Execute());
        }

        #endregion


        #region Methods

        public TurretInitializer AddNewTurret()
        {
            _newTurret = new TurretInitializer();

            _turretList.Add(_newTurret);

            return _newTurret;
        } 

        #endregion
    }
}