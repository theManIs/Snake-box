using UnityEngine;

namespace Snake_box
{
    public sealed class AcceleratingEnemy : BaseEnemy
    {
        #region PrivateData

        private AcceleratingEnemyData _data;
        private float _maxSpeed;
        private float _accelerating;
        

        #endregion

        
        #region ClassLifeCycle

        public AcceleratingEnemy() : base(Data.Instance.AcceleratingEnemy)
        {
            _data = Data.Instance.AcceleratingEnemy;
            Type = EnemyType.Accelerating;
            _accelerating = _data.Accelerating;
            _maxSpeed = _data.MaxSpeed;
            GetTarget();
        }
        
        #endregion


        #region IEnemy

        public override void Spawn()
        {
            base.Spawn();
            _navMeshAgent.acceleration = _accelerating;
            _navMeshAgent.speed = _maxSpeed;
            CustomDebug.Log(_navMeshAgent.acceleration);
            CustomDebug.Log(_accelerating);
        }

        #endregion

        #region Methods

        protected override void GetDamage(float damage)
        {
            base.GetDamage(damage);
            if (_hp > 0)
            {
                _navMeshAgent.velocity = Vector3.forward * _speed;
            }
            
        }

        #endregion
    }
}
