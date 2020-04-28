using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    public sealed class CharacterBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private float _rayDistantion;
        private CharacterData _characterData;
        private BlockSnakeData _blockSnakeData;
        private readonly List<BlockSnake> _blocksSnakes = new List<BlockSnake>();//блоки
        private readonly List<Vector3> _positions = new List<Vector3>();// позиции блоков 
        private float _sizeBlock;
        
        #endregion


        #region Unity Method

        private void Awake()
        {   
            for (int i = 0; i < _blocksSnakes.Count; i++)// проверяем и создоем хвост если есть
            {
                AddBlock();
            }
            _sizeBlock = (gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.sqrMagnitude);// размер
            _characterData = Data.Instance.Character;
            _positions.Add(gameObject.transform.position);//позиция головы             
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
            }
        }
       

        public void Collision()
        {
            var tagCollider = Services.Instance.PhysicsService.GetCollider(transform.position,transform.forward,_rayDistantion);           

            if (tagCollider)
            {                
                if (tagCollider.CompareTag(TagManager.GetTag(TagType.Bonus)))
                {
                    Destroy(tagCollider.transform.gameObject);                   
                    _particle.Play();
                }
                if (tagCollider.CompareTag(TagManager.GetTag(TagType.Base)))
                {
                    
                }
                if (tagCollider.CompareTag(TagManager.GetTag(TagType.Wall)))
                {                   
                    _particle.Play();
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

        public void Move(float inputAxis)//движение
        {           
            transform.Rotate(0,inputAxis*90,0);// переделать!!!!!!!!!!!!
            transform.position += transform.right*(_characterData.GetSpeed() / (_positions.Count + _characterData.GetSlow()));
            Collision();
            ResetPosition();

        }

        #endregion
    }
}
