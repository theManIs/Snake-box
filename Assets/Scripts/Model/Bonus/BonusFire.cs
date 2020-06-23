using UnityEngine;

namespace Snake_box
{
    public class BonusFire : BaseBonus
    {
        #region Fields

        private BonusFireData _bonusFireData;
        private int _bulletCount;       
        private Quaternion _rotation;
        private BonusBullet _bullet;

        #endregion


        #region Methods

        public BonusFire() : base(Data.Instance.BonusFireData)
        {
            _bonusFireData = Data.Instance.BonusFireData;
            _bulletCount = _bonusFireData.BulletCount;
            _prefab = _bonusFireData.Prefab;           
            _rotation = new Quaternion();
            _bullet = new BonusBullet();
        }

        public override void Use()
        {            
            base.Use();
            for (int i = 0; i < _bulletCount; i++)
            {                
                _rotation = Quaternion.Euler(0, 90 + i * 5, 0);
                _bullet = new BonusBullet();
                _bullet.Spawn(GetTransform(), _rotation);                
            }           
        }        

        #endregion
    }
}
