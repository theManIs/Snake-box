using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    public sealed class BlockSnake 
    {
        #region Fields

        private const int TURRET_PRICE = 20;
        
        private TurretController _turretController;
        private BlockSnakeData _blockSnakeData;
        private bool _turret;
        private float _hpBlock;//увиличения здоровья змейки при добовление блока
        private float _slowSnake;
        private int _coins;
        private Transform _prefab;

        #endregion


        #region  Method

        public  BlockSnake() 
        {             
            _blockSnakeData = Data.Instance.BlockSnake;
            _hpBlock = _blockSnakeData.HpBlock;
            _slowSnake = _blockSnakeData.SlowSnake;
            _coins = _blockSnakeData.Coins;
            _prefab = _blockSnakeData.Prefab;
        }

        public  void Spawn(GameObject position)
        {
            _prefab = Object.Instantiate(_prefab);
            _prefab.transform.SetParent(position.transform);
            Services.Instance.LevelService.BlockSnakes.Add(this);
        }


        #endregion


        #region Method

        public void AddTurret()
        {
            if (!_turret && Wallet.CountLocalCoins() >= TURRET_PRICE)
            {
                Data.Instance.TurretData.AddNewWithParent(_prefab.transform);
                Wallet.TakeLocalCoins(TURRET_PRICE);                
                _turret = true;
            }
        }

        public bool GetHasTurrel()
        {
            return _turret;
        }

        public float GetHp()
        {
            return _hpBlock;
        }

        public Transform GetTransform()
        {
            return _prefab;
        }

        #endregion
    }
}
