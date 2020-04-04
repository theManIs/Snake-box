using UnityEngine;


namespace BottomlessCloset
{
    [DisallowMultipleComponent]
    public sealed class ItemPhysics : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _angle;
        [SerializeField] private Collider2D _collider2D;
        private Rigidbody2D _rigidbody2D;
        private int _gameObjectId;
        private bool _isCollision;
        private bool _isFloor;

        #endregion


        #region Propertes
        
        public bool IsCollision => _isCollision;

        public bool IsFloor => _isFloor;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _gameObjectId = gameObject.GetInstanceID();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.GetTag(TagType.Floor)))
            {
                _isFloor = true;
                _isCollision = false;
            }

            if (!IsFloor)
            {
                _isCollision = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(TagManager.GetTag(TagType.Floor)))
            {
                _isFloor = false;
            }

            if (!IsFloor)
            {
                _isCollision = false;
            }
        }

        #endregion
        
        
        #region Methods

        public void MovePosition(Vector3 position)
        {
            _rigidbody2D.MovePosition(position);
        }

        public void MoveRotation()
        {
            if (IsFloor)
            {
                _rigidbody2D.MoveRotation(_rigidbody2D.rotation + _angle);
            }
        }

        public void EnablePhysics(int gameObjectId = -1)
        {
            if (IsFloor)
            {
                _collider2D.isTrigger =  true;
                _rigidbody2D.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                _collider2D.isTrigger = false;
                _rigidbody2D.gravityScale = 1.0f;
                _rigidbody2D.constraints = RigidbodyConstraints2D.None;
                _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        public void DisablePhysics(int gameObjectId = -1)
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            if (gameObjectId == _gameObjectId)
            {
                _collider2D.isTrigger =  true;
                _rigidbody2D.constraints = RigidbodyConstraints2D.None;
            }
            else
            {
                _collider2D.isTrigger = false;
                _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
            }
            _rigidbody2D.gravityScale = 0.0f;
        }

        #endregion
    }
}
