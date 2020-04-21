using System.Collections.Generic;
using UnityEngine;


namespace ExampleTemplate
{
    public sealed class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private float _rayDistantion;
        private CharacterData _characterData;
        private BlockSnakeData _blockSnakeData;
        private readonly List<BlockSnake> _blocksSnakes = new List<BlockSnake>();//блоки
        private readonly List<Vector2> _positions = new List<Vector2>();// позиции блоков 
        private float _sizeBlock;        

        private void Awake()
        {               
            for (int i = 0; i < _blocksSnakes.Count; i++)// проверяем и создоем хвост если есть
            {
                AddBlock();
            }
            _sizeBlock = (gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.magnitude) / 2;// размер
            _characterData = Data.Instance.Character;
            _positions.Add(gameObject.transform.position);//позиция головы             
        }               

        public void ResetPosition()///выставление блока
        {
            float distance = ((Vector2)gameObject.transform.position - _positions[0]).magnitude;/// текущая текущай  поз и последней
            if (distance > _sizeBlock) ///проверяем дистанцию длля перемещения
            {
                // Направление от старого положения головы, к новому
                Vector2 direction = ((Vector2)gameObject.transform.position - _positions[0]).normalized;
                _positions.Insert(0, _positions[0] + direction * _sizeBlock);
                _positions.RemoveAt(_positions.Count - 1);
                distance -= _sizeBlock;
            }
            if (_blocksSnakes.Count != 0)
            {
                for (int i = 0; i < _blocksSnakes.Count; i++)// перебираем блоки
                {
                    _blocksSnakes[i].transform.position = Vector2.Lerp(_positions[i + 1], _positions[i], distance / _sizeBlock);
                    _blocksSnakes[i].transform.rotation = transform.rotation;
                }
            }
        }

        public void AddBlock()// добавление блока
        {
            _blockSnakeData = Data.Instance.BlockSnake;
            var block = _blockSnakeData.Initialization();
            block.transform.SetParent(gameObject.transform);
            block.transform.position = _positions[_positions.Count - 1];            
            _blocksSnakes.Add(block);                        
            _positions.Add(block.transform.position);            
        }

        public void Collision()
        {
            var tagCollider = Services.Instance.PhysicsService.GetCollider(transform.position,transform.forward,_rayDistantion);           

            if (tagCollider)
            {                
                if (tagCollider.CompareTag(TagManager.GetTag(TagType.Bonus)))
                {
                    Destroy(tagCollider.transform.gameObject);
                }
                if (tagCollider.CompareTag(TagManager.GetTag(TagType.Base)))
                {
                    
                }
                if (tagCollider.CompareTag(TagManager.GetTag(TagType.Wall)))
                {
                    
                }
            }
        }

        public void Move(float inputAxis)//движение
        {           
            ResetPosition();
            transform.Rotate(0,0, inputAxis*90);// переделать!!!!!!!!!!!!
            transform.position += transform.right*(_characterData.GetSpeed() / (_positions.Count + _characterData.GetSlow()));
            Collision();
        }
    }
}
