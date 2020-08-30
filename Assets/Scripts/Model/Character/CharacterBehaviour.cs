using System;
using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    public sealed class CharacterBehaviour : BaseCharacter
    {
        private const float TELEPORTATION_OFFSET = 0.1f;

        #region Fields       

        [SerializeField] private float _radius;
        private CharacterData _characterData;
        //private readonly List<BlockSnake> _blocksSnakes = new List<BlockSnake>();//блоки
        //private readonly List<Vector3> _positions = new List<Vector3>();// позиции блоков 
        //private float _sizeBlock;       
        private Direction _direction = Direction.Up;
        private ITimeService _timeService;
        private bool hasSkill;
        private BonusData _bonus;
        private GameObject _player;//переделать через сервис
        private float _slowSnake;
        private float _ramCooldown;
        private float _currentRamCooldown = 0;
        private Queue<GameObject> _pointsTurret;

        #endregion

        #region Propeties

        public GameObject Player => _player;

        #endregion

        #region Unity Method

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Player));
            _timeService = Services.Instance.TimeService;
            //_sizeBlock = (gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.sqrMagnitude);// размер
            _characterData = Data.Instance.Character;
            //_positions.Add(gameObject.transform.position);//позиция головы
            _currentArmor = _characterData.Armor;
            _baseArmor = _characterData.Armor;
            _currentSnakeHp = _characterData.Hp;
            _baseSnakeHp = _characterData.Hp;
            _damage = _characterData.Damage;
            _speed = _characterData.Speed;
            _snakeArmorGeneration = _characterData.RegenerationArmor;
            _ramCooldown = _characterData.RamCooldown;
            _pointsTurret = new Queue<GameObject>();
            var pointTurrets = GameObject.FindGameObjectsWithTag(TagManager.GetTag(TagType.TurretPoint));
            if (pointTurrets.Length != 0)
            {
                foreach (GameObject points in pointTurrets)
                {
                    _pointsTurret.Enqueue(points);
                }
            }
        }

        #endregion


        #region Methods

        public void UseBonus()
        {
            //if (hasSkill)
            //{               
            //    _bonus.Use(gameObject.GetComponent<CharacterBehaviour>());
            //    hasSkill = false;
            //}            
        }

        //public void ResetPosition()///выставление блока
        //{
        //    float distance = ((Vector3)gameObject.transform.position - _positions[0]).magnitude;/// текущая текущай  поз и последней         
        //    if (_blocksSnakes.Count != 0)
        //    {
        //        for (int i = 0; i < _blocksSnakes.Count; i++)// перебираем блоки
        //        {
        //            _blocksSnakes[i].GetTransform().position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / _sizeBlock);
        //            _blocksSnakes[i].GetTransform().rotation = transform.rotation;
        //        }
        //    }
        //    if (distance > _sizeBlock) ///проверяем дистанцию длля перемещения
        //    {
        //        // Направление от старого положения головы, к новому
        //        Vector3 direction = (gameObject.transform.position - _positions[0]).normalized;
        //        _positions.Insert(0, _positions[0] + direction * _sizeBlock);
        //        _positions.RemoveAt(_positions.Count - 1);
        //        distance -= _sizeBlock;
        //    }
        //}

        //public void AddBlock()// добавление блока
        //{
        //    if (_blocksSnakes.Count < 4)
        //    {                
        //        var block = new BlockSnake();
        //        block.Spawn(_player);
        //        block.GetTransform().position = _positions[_positions.Count - 1];
        //        _blocksSnakes.Add(block);
        //        _positions.Add(block.GetTransform().position);
        //        _currentSnakeHp += block.GetHp();
        //        _baseSnakeHp += block.GetHp();
        //        Services.Instance.FlyingIconsService.CreateFlyingBlock();
        //    }
        //}

        public void Collision()
        {
            var tagCollider = Physics.OverlapSphere(transform.position, _radius);
            for (int i = 0; i < tagCollider.Length; i++)
            {
                if (tagCollider[i].CompareTag(TagManager.GetTag(TagType.Bonus)))
                {
                    hasSkill = true;
                    for (int b = 0; b < Services.Instance.LevelService.ActiveBonus.Count; b++)
                    {
                        if (Services.Instance.LevelService.ActiveBonus[b].GetTransform() == tagCollider[i].transform)
                        {
                            Services.Instance.LevelService.ActiveBonus[b].Use();
                        }
                    }
                }
            }
        }

        //public BlockSnake GetBlock(int indexBlock)
        //{
        //    if (indexBlock < _blocksSnakes.Count)
        //    {
        //        return _blocksSnakes[indexBlock];
        //    }
        //    else return null;
        //}

        public void ConstantMove()//постоянное движение
        {
            transform.rotation = _direction.ToQuaternion();
            transform.position += transform.forward * ((_speed /*- (_positions.Count * _slowSnake)*/) * _timeService.DeltaTime());
        }

        public void InputMove(Direction direction)//движение
        {
            if (direction != Direction.None && !direction.IsOpposite(_direction))
                _direction = direction;
            TeleportIfOutOfBorder();
        }

        public void RegenerationArmor()
        {
            if (_currentArmor < _baseArmor)
            {
                _currentArmor = _currentArmor + (SnakeArmorGeneration * _timeService.DeltaTime());
            }
        }

        public void TeleportIfOutOfBorder()
        {
            BordersData bordersData = Data.Instance.BordersData;
            if (transform.position.x < bordersData.LeftBorderX)
                transform.position = new Vector3(bordersData.RightBorderX - TELEPORTATION_OFFSET, transform.position.y, transform.position.z);
            if (transform.position.x > bordersData.RightBorderX)
                transform.position = new Vector3(bordersData.LeftBorderX + TELEPORTATION_OFFSET, transform.position.y, transform.position.z);
            if (transform.position.z < bordersData.BottomBorderZ)
                transform.position = new Vector3(transform.position.x, transform.position.y, bordersData.TopBorderZ - TELEPORTATION_OFFSET);
            if (transform.position.z > bordersData.TopBorderZ)
                transform.position = new Vector3(transform.position.x, transform.position.y, bordersData.BottomBorderZ + TELEPORTATION_OFFSET);
        }

        public void SetDamage(IDamageAddressee damageAddressee)
        {
            damageAddressee.RegisterDamage(_damage, ArmorTypes.None);
        }

        public void RamEnemy(BaseEnemy enemy)
        {
            if (_currentRamCooldown == 0)
            {
                enemy.RegisterDamage(_damage, ArmorTypes.None);
                _currentRamCooldown = _ramCooldown;
            }
        }

        public void DecreaseRamCooldown()
        {
            _currentRamCooldown -= Services.Instance.TimeService.DeltaTime();
            if (_currentRamCooldown < 0)
                _currentRamCooldown = 0;
        }

        public Transform GetPoint()
        {
            if (_pointsTurret.Count != 0)
            {
                return _pointsTurret.Dequeue().transform;
            }
            return null;
          
        }

        #endregion
    }
}
