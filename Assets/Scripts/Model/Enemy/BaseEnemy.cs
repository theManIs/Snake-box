using System;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Snake_box
{
    public abstract class BaseEnemy : IEnemy
    {
        #region PrivateData

        protected float _hp;
        protected Transform _transform;
        protected Transform _target;
        protected Vector3 _SpawnCenter;
        protected float _spawnRadius;
        protected NavMeshAgent _navMeshAgent;
        protected bool _isNeedNavMeshUpdate = false;
        protected GameObject prefab;
        #endregion

        #region Properties

        public EnemyType Type { get; protected set; }

        #endregion

        #region Methods

        public abstract void Spawn();

        #endregion

        public abstract void OnUpdate();

    }
}
