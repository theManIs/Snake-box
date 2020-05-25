using UnityEngine;


namespace Snake_box
{
    public sealed class Wallet
    {
        #region Fields       

        private const string Key = "WorldCoins";
        private static int _localCoins;

        #endregion


        #region Methods

        public static int CountWorldCoins()///прибавить валюту
        {
            return Services.Instance.SaveData.GetInt(Key);
        }

        public static void PutWorldCoins(int count)///прибавить валюту
        {
            Services.Instance.SaveData.SetInt(Key, Services.Instance.SaveData.GetInt(Key) + count);           
        }

        public static void TakeWorldCoins(int count)
        {
            if (count <= CountWorldCoins())
            {
                Services.Instance.SaveData.SetInt(Key, Services.Instance.SaveData.GetInt(Key)- count);  
            }            
        }

        public static int CountLocalCoins()///прибавить валюту
        {
            return _localCoins;
        }

        public static void TakeLocalCoins(int count)
        {
            if (count <= _localCoins)
            {
                _localCoins -= count;//отнять валюту
            }
        }

        public static void PutLocalCoins(int count)///прибавить валюту
        {
            _localCoins += count;
        }

        public static void  ResetLocalCoins()///прибавить валюту
        {
            _localCoins = 0;
        }

        #endregion
    }
}
