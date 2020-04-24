using Assets.Scripts.Model.Turrets;
using ExampleTemplate;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Controllers
{
    public class TurretProjectileController : IExecute
    {
        private static GameObject _turretPrefab = Resources.Load<GameObject>("Prefabs/Turrets/TurretFireball");

        private static List<TurretProjectileAbs> _turretProjectiles = new List<TurretProjectileAbs>();

        public static void SpawnRegularBullet(Transform firePoint, Transform enemy)
        {
            //todo put this method into builder
            GameObject prefabObject = Object.Instantiate(_turretPrefab, Vector3.zero, Quaternion.identity);
            TurretProjectile turretProjectile = new TurretProjectile();

            turretProjectile.SetGameObject(prefabObject);
            turretProjectile.SetFirePoint(firePoint);
            turretProjectile.SetTarget(enemy);
            turretProjectile.SetSelfDestruct(5);
            turretProjectile.CountDistance();

            _turretProjectiles.Add(turretProjectile);
        }

        public void Execute()
        {
            _turretProjectiles.ForEach(iExecutable => iExecutable.Execute());

            _turretProjectiles = _turretProjectiles.Where(x => !x.IsToDispose()).ToList();

//            Debug.Log(new StackTrace(true).GetFrame(1).GetFileLineNumber() + ": to dispose " +_turretProjectiles.Count(x => !x.IsToDispose()));
//            Debug.Log(new StackTrace(true).GetFrame(1).GetFileLineNumber() + ": whole count " +_turretProjectiles.Count);
        }
    }
}