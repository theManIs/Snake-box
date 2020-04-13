using UnityEngine;
using UnityEngine.AI;

namespace ExampleTemplate
{
    public abstract class BaseEnemy : IEnemy
    {
        #region PrivateData

        protected float _hp;
        protected Transform _transform;
        protected Transform _target;
        protected NavMeshAgent _navMeshAgent;
        protected bool _needSetupNavMesh;

        #endregion

        #region Properties

        public EnemyType Type { get; protected set; }

        #endregion

        #region Methods

        public virtual void Spawn()
        {
            var enemy =  Object.Instantiate((GameObject)Resources.Load(AssetsPathGameObject.EnemyObjects[Type]));
            _navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            _transform = enemy.transform;
        }

        #endregion

        public abstract void OnUpdate();

    }
}
