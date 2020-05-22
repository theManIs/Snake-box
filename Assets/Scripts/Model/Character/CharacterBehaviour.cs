using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    public sealed class CharacterBehaviour : MonoBehaviour
    {
        #region Fields       

        [SerializeField] private float _radius;
        private CharacterData _characterData;
        private BlockSnakeData _blockSnakeData;
        private readonly List<BlockSnake> _blocksSnakes = new List<BlockSnake>();//блоки
        private readonly List<Vector3> _positions = new List<Vector3>();// позиции блоков 
        private float _sizeBlock;
        private float _snakeHp;
        private float _snakeArmorCurrent;
        private float _armorMax;
        private float _snakeHpMax;
        private float _snakeArmorGeneration = 1;
        private float _damage;
        private float _speed;
        private float _slowSpeed;
        private ITimeService _timeService;
        private Direction _direction = Direction.Up;

        #endregion


        #region Properties
        public float SnakeHp { get { return _snakeHp; } }
        public float SnakeHpMax { get { return _snakeHpMax; } }
        public float SnakeArmorCurrent { get { return _snakeArmorCurrent; } }
        public float SnakeArmorMax { get { return _armorMax; } }

        #endregion


        #region Unity Method

        private void Awake()
        {
            _timeService = Services.Instance.TimeService;
            _sizeBlock = (gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.sqrMagnitude);// размер
            _characterData = Data.Instance.Character;
            _positions.Add(gameObject.transform.position);//позиция головы
            _snakeArmorCurrent = _characterData._armor;
            _armorMax = _characterData._armor;
            _snakeHp = _characterData._hp;
            _snakeHpMax = _characterData._hp;
            _damage = _characterData._damage;
            _speed = _characterData._speed;
            _slowSpeed = _characterData._slowSpeed;
        }

        #endregion


        #region Methods

        public void ResetPosition()///выставление блока
        {
            float distance = ((Vector3)gameObject.transform.position - _positions[0]).magnitude;/// текущая текущай  поз и последней         
            if (_blocksSnakes.Count != 0)
            {
                for (int i = 0; i < _blocksSnakes.Count; i++)// перебираем блоки
                {
                    _blocksSnakes[i].transform.position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / _sizeBlock);
                    _blocksSnakes[i].transform.rotation = transform.rotation;
                }
            }
            if (distance > _sizeBlock) ///проверяем дистанцию длля перемещения
            {
                // Направление от старого положения головы, к новому
                Vector3 direction = (gameObject.transform.position - _positions[0]).normalized;
                _positions.Insert(0, _positions[0] + direction * _sizeBlock);
                _positions.RemoveAt(_positions.Count - 1);
                distance -= _sizeBlock;
            }
        }

        public void AddBlock()// добавление блока
        {
            if (_blocksSnakes.Count < 4)
            {
                _blockSnakeData = Data.Instance.BlockSnake;
                var block = _blockSnakeData.Initialization();
                block.transform.SetParent(gameObject.transform);
                block.transform.position = _positions[_positions.Count - 1];
                _blocksSnakes.Add(block);
                _positions.Add(block.transform.position);
                _snakeHp += _blockSnakeData.GetHp();
            }
        }


        public void Collision()
        {
            var tagCollider = Physics.OverlapSphere(transform.position, _radius);

            for (int i = 0; i < tagCollider.Length; i++)
            {
                if (tagCollider[i].CompareTag(TagManager.GetTag(TagType.Bonus)))
                {
                    Destroy(tagCollider[i].transform.gameObject);
                }
                if (tagCollider[i].CompareTag(TagManager.GetTag(TagType.Base)))
                {

                }
                if (tagCollider[i].CompareTag(TagManager.GetTag(TagType.Wall)))
                {

                }
            }
        }

        public BlockSnake GetBlock(int indexBlock)
        {
            if (indexBlock < _blocksSnakes.Count)
            {
                return _blocksSnakes[indexBlock];
            }
            else return null;
        }

        public void Move(Direction direction)//движение
        {
            if (direction != Direction.None && !direction.IsOpposite(_direction))
                _direction = direction;
            transform.rotation = _direction.ToQuaternion();
            transform.position += transform.forward * ((_speed * _timeService.DeltaTime()) / (_positions.Count + _slowSpeed));
            Collision();
            ResetPosition();
        }

        public void RegenerationArmor()
        {
            if (_snakeArmorCurrent < _armorMax)
            {
                _snakeArmorCurrent = _snakeArmorCurrent + (_snakeArmorGeneration * Services.Instance.TimeService.DeltaTime());
            }
        }

        public void SetDamage(float damage)///нанесения урона без зашиты
        {
            _snakeHp -= damage;
            if (_snakeHp <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            gameObject.SetActive(false);
            Services.Instance.LevelService.IsSnakeAlive = false;
            Services.Instance.LevelService.EndLevel();
        }

        public void SetArmor(float damage)///нанесения урона с зашитой
        {
            _snakeArmorCurrent -= damage;
            if (_snakeArmorCurrent < 0)// если защита отрицательная 
            {
                SetDamage(_snakeArmorCurrent); /// то урон переносится на HP
            }
        }
        #endregion
    }
}
