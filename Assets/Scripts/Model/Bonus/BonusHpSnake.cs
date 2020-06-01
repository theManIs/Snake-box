using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Snake_box
{
    public class BonusHpSnake : BaseBonus
{
        private BonusHpSnakeData _bonusHpSnakeData;
        private int _hpSnake;

        public BonusHpSnake() : base(Data.Instance.BonusHpSnakeData)
        {
            _bonusHpSnakeData = Data.Instance.BonusHpSnakeData;
            _hpSnake = _bonusHpSnakeData.HpSnake;
        }

        public override void Use()
        {
            base.Use();
            Data.Instance.Character.CharacterBehaviour.SnakeHp += _hpSnake;
        }
    }
}
