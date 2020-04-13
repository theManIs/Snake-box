using UnityEngine;

namespace ExampleTemplate
{
    public abstract class BaseEnemy : IEnemy
    {
        #region PrivateData

        protected float _hp;
        protected Transform _transform;
        protected Transform _target;

        #endregion

        #region Properties

        public EnemyType Type { get; protected set; }

        #endregion

        #region Methods

        public abstract void Move();

        public virtual void Spawn()
        {
            var enemy =  Object.Instantiate((GameObject)Resources.Load(AssetsPathGameObject.EnemyObjects[Type]));
            _transform = enemy.transform;
        }

        #endregion

        public abstract void OnUpdate();

    }
}
