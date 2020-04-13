using UnityEngine;

namespace ExampleTemplate
{
    public sealed class SimpleEnemy : BaseEnemy
    {
        #region PrivateData

        private float _speed = 10.0f;
        private float _damage;

        #endregion

        #region ClassLifeCycles

        public SimpleEnemy() //TODO переделать по человечески
        {
            Type = EnemyType.Simple;
            GetTarget();
        }

        #endregion

        #region Methods

        public override void Move()
        {
            if (_transform.position.CalcDistance(_target.position) > 3.0f)
            {
                _transform.rotation = Quaternion.Slerp(_transform.rotation,
                    Quaternion.LookRotation(_target.position - _transform.position), 0.3f);
                _transform.position += Time.deltaTime * _speed * _transform.forward;
            }
        }

        public override void OnUpdate()
        {
            Move();
            HitCheck();
        }

        public void HitCheck()
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(_transform.position, 3.1f, colliders);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != null)
                    if (colliders[i].CompareTag("Target"))
                    {
                        Debug.Log("I Found It!");
                        Object.Destroy(colliders[i]);
                    }
            }
        }

        private void GetTarget()
        {
            _target = GameObject.FindWithTag("Target").transform;
        }

        #endregion
    }
}
