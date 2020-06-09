using System.Collections.Generic;


namespace Snake_box
{
    public class BonusList
    {
        #region Fields

        public List<BaseBonus> _bonusList = new List<BaseBonus>();

        #endregion


        #region ClassLifeCycle

        public BonusList()
        {           
            _bonusList.Add(new BonusCoins());
            _bonusList.Add(new BonusHpSnake());
            _bonusList.Add(new BonusSpeed());
        }

        #endregion

    }
}
