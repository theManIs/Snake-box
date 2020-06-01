using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Snake_box
{
    public abstract class TurretProjectileAbs : IExecute
    {
        #region Fields

        private IEnemy _targetToPursue;
        private float _timeStart;
        private GameObject _projectileInstance;
        private Transform _firePoint;
        private float _timeToBeDestructedAfter = 10;
        protected bool ToDispose = false;
        public int ObjectId;
        private float _journeyDistance;
        private bool _targetLocked = false;
        private Vector3 _angleLock = new Vector3(90, 0, 0);

        #endregion


        #region Methods

        public abstract ArmorTypes GetArmorType();

        public abstract float GetCarryingDamage();

        public abstract void Execute();

        public abstract int GetBulletSpeed();

        public void SetTarget(IEnemy enemyTransform)
        {
            _targetToPursue = enemyTransform;
            _targetLocked = true;
        }

        public void SetLookRotation(Transform lookAt)
        {
            if (_projectileInstance)
            {
//                _projectileInstance.transform.LookAt(lookAt);
//
//                Vector3 eulerAngles = _projectileInstance.transform.rotation.eulerAngles;
//                eulerAngles.x = _angleLock.x;
//                _projectileInstance.transform.rotation = Quaternion.Euler(eulerAngles);

                Vector3 direction3d = lookAt.position - _projectileInstance.transform.position;
                Vector3 eulerAngles = Quaternion.LookRotation(direction3d).eulerAngles;
                eulerAngles.x = _angleLock.x;
                _projectileInstance.transform.rotation = Quaternion.Euler(eulerAngles);
            }
        }

        public void CountDistance()
        {
            if (_firePoint && _targetToPursue != null)
                _journeyDistance = Vector3.Distance(_firePoint.position, _targetToPursue.GetTransform().position);
        }

        public void SetFirePoint(Transform firePoint)
        {
            _firePoint = firePoint;

            _projectileInstance.transform.position = _firePoint.position;
//            _projectileInstance.transform.rotation = _firePoint.rotation;
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
            if (_targetLocked && (_targetToPursue == null || _targetToPursue.AmIDestroyed()))
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
                || Math.Abs(_journeyDistance) <= 0.0f
                || _targetToPursue.AmIDestroyed())
                return;

            float projectileLifespan = Time.time - _timeStart;
            float coveredDistance = projectileLifespan * GetBulletSpeed();
            float interpolation = coveredDistance / _journeyDistance;

            _projectileInstance.transform.position = 
                Vector3.Lerp(_firePoint.transform.position, _targetToPursue.GetTransform().position, interpolation);

            if (interpolation >= 1 || _timeToBeDestructedAfter < projectileLifespan)
                Decommission();
        }

        public bool IsToDispose() => ToDispose;

        protected void Decommission()
        {
            if (!_targetToPursue.AmIDestroyed())
            {
                if (_targetToPursue is IDamageAddressee ida) 
                    ida.RegisterDamage(GetCarryingDamage(), GetArmorType());
            }

            ToDispose = true;

            Object.Destroy(_projectileInstance.gameObject);
        }

        #endregion
    }
}