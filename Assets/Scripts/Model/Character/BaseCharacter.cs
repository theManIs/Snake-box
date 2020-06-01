using UnityEngine;


namespace Snake_box
{
    public abstract class BaseCharacter : MonoBehaviour
    {

        #region Fields     

        protected float _snakeHp;
        protected float _snakeArmorCurrent;
        protected float _armorMax;
        protected float _snakeHpMax;
        protected float _snakeArmorGeneration = 1;
        protected float _damage;
        protected float _speed;
        protected float _slowSpeed;
        private Direction _direction = Direction.Up;

        #endregion


        #region Properties

        public float SnakeSpeed { get { return _speed; } set => _speed = value; }
        public float SnakeHp { get { return _snakeHp; } set => _snakeHp = value; }
        public float SnakeHpMax { get { return _snakeHpMax; } }
        public float SnakeArmorCurrent { get { return _snakeArmorCurrent; } }
        public float SnakeArmorMax { get { return _armorMax; } }

        #endregion


        #region Methods

        public void SetArmor(float damage)///нанесения урона с зашитой
        {
            _snakeArmorCurrent -= damage;
            if (_snakeArmorCurrent < 0)// если защита отрицательная 
            {
                SetDamage(-_snakeArmorCurrent); /// то урон переносится на HP
                _snakeArmorCurrent = 0;
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

        #endregion

    }
}
