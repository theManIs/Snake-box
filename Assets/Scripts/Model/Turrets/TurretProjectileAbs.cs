using System;
using System.Runtime.Serialization;
using ExampleTemplate;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Assets.Scripts.Model.Turrets
{
    public abstract class TurretProjectileAbs : IExecute
    {
        #region Fields

        private Transform _targetToPursue;
        private float _timeStart;

        private GameObject _projectileInstance;
        private Transform _firePoint;
        private float _timeToBeDestructedAfter = 10;
        protected bool ToDispose = false;
        public int ObjectId;
        private float _journeyDistance;
        private bool _targetLocked = false;

        #endregion


        #region Methods

        public abstract ArmorTypes GetArmorType();

        public abstract float GetCarryingDamage();

        public abstract void Execute();

        public abstract int GetBulletSpeed();


//        public TurretProjectileAbs Instantiate()
//        {
//            _timeStart = Time.time;
//
//            _projectileInstance = Resources.Load<GameObject>("Prefabs/Turrets/TurretFireball"); //todo move it in constructor or in static way
//
//            GameObject projectileInstance = Object.Instantiate(_projectileInstance, _firePoint.position, _firePoint.rotation);
//            TurretProjectileAbs _projectileClass = projectileInstance.GetComponent<TurretProjectileAbs>();
//
//            _projectileClass._firePoint = _firePoint;
//            _projectileClass._projectileInstance = projectileInstance;
//
//            return _projectileClass;
//        }


//        public void OnTriggerEnter2D(Collider2D collideInfo)
//        {
//            IDamageAddressee damageTarget = collideInfo.GetComponent<IDamageAddressee>();
//
////            Debug.Log(collideInfo.gameObject.name);
////            Destroy(gameObject);
////            Destroy(collideInfo.gameObject, 0.5f);
//
//            damageTarget?.RegisterDamage(GetCarryingDamage(), GetArmorType());
//        }

        public void SetTarget(Transform enemyTransform)
        {
            _targetToPursue = enemyTransform;
            _targetLocked = true;
        }

        public void CountDistance()
        {
            if (_firePoint && _targetToPursue)
                _journeyDistance = Vector3.Distance(_firePoint.position, _targetToPursue.position);
        }

        public void SetFirePoint(Transform firePoint)
        {
            _firePoint = firePoint;

            _projectileInstance.transform.position = _firePoint.position;
            _projectileInstance.transform.rotation = _firePoint.rotation;
        }

        public void SetGameObject(GameObject gm)
        {
            ObjectId = gm.GetInstanceID();
            
            _projectileInstance = gm;
        }

        public void SetSelfDestruct(float timeToBeDestructedAfter)
        {
            _timeStart = Time.time;
            _timeToBeDestructedAfter = timeToBeDestructedAfter;
        }

        private void DecommissionIfTargetDown()
        {
            if (_targetLocked && _targetToPursue == null)
            {
                Decommission();
            }
        }

        public void MoveAutoTarget()
        {
            DecommissionIfTargetDown();

            if (_projectileInstance == null 
                || Math.Abs(GetBulletSpeed()) <= 0 
                || _targetToPursue == null 
                || Math.Abs(_journeyDistance) <= 0.0f)
                return;

            float coveredDistance = (Time.time - _timeStart) * GetBulletSpeed();
            float interpolation = coveredDistance / _journeyDistance;

            _projectileInstance.transform.position = Vector3.Lerp(_firePoint.transform.position, _targetToPursue.position, interpolation);

            if (interpolation >= 1)
                Decommission();
        }

        public bool IsToDispose() => ToDispose;

        protected void Decommission()
        {
//            Debug.Log("Decommission");

            if (_targetToPursue)
            {
                IDamageAddressee ida = _targetToPursue.GetComponent<IDamageAddressee>();

                ida?.RegisterDamage(GetCarryingDamage(), GetArmorType());
            }

            ToDispose = true;

            Object.Destroy(_projectileInstance.gameObject);
        }

        #endregion

    }
}