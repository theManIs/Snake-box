using UnityEngine;

namespace ExampleTemplate
{
    public sealed class SimpleEnemy : BaseEnemy
    {
        #region PrivateData

        private GameObject Prefab; //TODO Вынести в SO;
        private Transform _transform;
        private Transform _target; //TODO для тестов, после заменить с использованием NavMesh; 
        private float _speed = 10.0f;
        private float _damage;

        #endregion

        #region ClassLifeCycles

        public SimpleEnemy() //TODO переделать по человечески
        {
            Prefab = (GameObject) Resources.Load("Prefabs/Enemies/SimpleEnemy");
            GetTarget();
        }

        #endregion

        #region Methods

        public override void Move()
        {
            _transform.rotation = Quaternion.Slerp(_transform.rotation,
                Quaternion.LookRotation(_target.position - _transform.position), Time.deltaTime);
            _transform.position += Time.deltaTime * _speed * _transform.forward;
        }

        private void GetTarget()
        {
            _target = GameObject.FindWithTag("Target").transform;
        }

        public override void Spawn() //TODO Вынести в базовый класс
        {
            var obj =  Object.Instantiate(Prefab);
            _transform = obj.transform;
        }

        #endregion
    }
}
