using UnityEngine;


namespace Snake_box
{
    public abstract class BaseBonus 
    {
        #region PrivateData

        protected Sprite _icon;// иконка
        protected Transform _prefab;
        protected Transform _bonus;
        protected TimeRemaining _lifeTimer;
        protected float _lifeTime;

        #endregion


        #region Methods

        public BaseBonus(BonusData BonusData)
        {
            _lifeTime = BonusData.LifeTime;
            _lifeTimer = new TimeRemaining(LifeTimer, _lifeTime);
            _icon = BonusData.Icon;            
            _prefab = BonusData.Prefab;            
        }

        protected virtual void LifeTimer()
        {
            Object.Destroy(_bonus.gameObject);
            Services.Instance.LevelService.ActiveBonus.Remove(this);
        }

        public virtual void Spawn(Vector3 position)
        {
            _bonus = Object.Instantiate(_prefab, position, Quaternion.identity);
            Services.Instance.LevelService.ActiveBonus.Add(this);
            _lifeTimer.AddTimeRemaining();
        }

        public virtual Transform GetTransform()
        {
            return _bonus;
        }

        public virtual void Use()
        {
            _lifeTimer.RemoveTimeRemaining();
            Services.Instance.LevelService.ActiveBonus.Remove(this);
            Object.Destroy(_bonus.gameObject);
        }
        
        #endregion

    }
}