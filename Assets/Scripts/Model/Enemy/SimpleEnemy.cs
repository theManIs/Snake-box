using UnityEngine;
using UnityEngine.AI;

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
            _needSetupNavMesh = true;

        }

        #endregion

        #region Methods

        public override void OnUpdate()
        {
            if (_needSetupNavMesh)
            {
                NavMeshSetup();
            }
            HitCheck();
        }

        public void NavMeshSetup()
        {
            _navMeshAgent.SetDestination(_target.transform.position);
            _navMeshAgent.speed = _speed;
            _navMeshAgent.stoppingDistance = 2.5f;
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
