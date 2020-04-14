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
        private float _distance;

        private void Awake()
        {          
            _characterData = Data.Instance.Character;            
            _positions.Add(gameObject.transform.position);//позиция головы             
        }

        public void ResetPosition()///выставление блока
        {
            _distance = ((Vector2)gameObject.transform.position - _positions[0]).magnitude;/// текущая текущай  поз и последней
            if (_distance > _characterData.GetDistance()) ///проверяем дистанцию длля перемещения
            {
                // Направление от старого положения головы, к новому
                Vector2 direction = ((Vector2)gameObject.transform.position - _positions[0]).normalized;
                _positions.Insert(0, _positions[0] + direction * _characterData.GetDistance());
                _positions.RemoveAt(_positions.Count - 1);
                _distance -= _characterData.GetDistance();
            }
            if (_blocksSnakes.Count != 0)
            {
                for (int i = 0; i < _blocksSnakes.Count; i++)// перебираем блоки
                {  
                    _blocksSnakes[i].transform.position = Vector2.Lerp(_positions[i + 1], _positions[i], _distance / _characterData.GetDistance());                   
                }
            }
        }
        
        public void AddBlock()// добавление блока
        {
            _blockSnakeData = Data.Instance.BlockSnake;
            var block = _blockSnakeData.Initialization();
            block.transform.SetParent(gameObject.transform);
            block.transform.position =new Vector2( _positions[_positions.Count - 1].x+block.GetComponent<MeshRenderer>().bounds.size.x, _positions[_positions.Count - 1].y);            
            _blocksSnakes.Add(block);                        
            _positions.Add(block.transform.position);            
        }

        public void Move(Vector3 moveDirection)//движение
        {
            ResetPosition();
            transform.Translate(transform.right * moveDirection.x * (_characterData.GetSpeed() / (_positions.Count+ _characterData.GetSlow())));
            transform.Translate(transform.up * moveDirection.y * (_characterData.GetSpeed() / (_positions.Count + _characterData.GetSlow())));
        }
    }
}
