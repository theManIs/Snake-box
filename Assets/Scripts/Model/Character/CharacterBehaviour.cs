using System.Collections.Generic;
using UnityEngine;


namespace ExampleTemplate
{
    public sealed class CharacterBehaviour : MonoBehaviour
    {        
        private CharacterData _characterData;
        private BlockSnakeData _blockSnakeData;
        private List<BlockSnake> _blocksSnakes = new List<BlockSnake>();//блоки
        private List<Vector2> _positions = new List<Vector2>();// позиции блоков 
        private float _sizeBlock;
        private RaycastHit _hit;
        [SerializeField] private TagType _tagType;

        private void Awake()
        {               
            for (int i = 0; i < _blocksSnakes.Count; i++)
            {
                AddBlock();
            }
            _sizeBlock = (gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.size.magnitude) / 2;
            _characterData = Data.Instance.Character;
            _positions.Add(gameObject.transform.position);//позиция головы             
        }

        private void FixedUpdate()
        {
            Collision();
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
            if (Physics.Raycast(transform.position, -Vector3.right, out _hit, 1.0f))
            {
                if (_hit.collider.CompareTag(TagManager.GetTag(_tagType = TagType.Bonus)))
                {
                    Debug.Log("Bonus");
                    Destroy(_hit.transform.gameObject);
                }
                if (_hit.collider.CompareTag(TagManager.GetTag(_tagType = TagType.Base)))
                {
                    Debug.Log("Base");
                }
                if (_hit.collider.CompareTag(TagManager.GetTag(_tagType = TagType.Wall)))
                {
                    Debug.Log("Wall");
                }
            }
        }

        public void Move(float inputAxis)//движение
        {            
            ResetPosition();
            transform.Rotate(0,0, inputAxis * (_characterData.GetSpeed() * _characterData.GetSpeedRotation())*90);
            transform.position += transform.right*(_characterData.GetSpeed() / (_positions.Count + _characterData.GetSlow()));            
        }
    }
}
