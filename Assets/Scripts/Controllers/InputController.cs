using UnityEngine;
using UnityEngine.SceneManagement;

namespace Snake_box
{
    public sealed class InputController : IExecute
    {
        #region Private Data

        private KeyCode _left = KeyCode.A;
        private KeyCode _right = KeyCode.D;
        private KeyCode _up = KeyCode.W;
        private KeyCode _down = KeyCode.S;

        #endregion

        private readonly CharacterData _characterData;

        public InputController()
        {
            _characterData = Data.Instance.Character;           
        }

        #region IExecute

        public void Execute()
        {
            Direction direction = Direction.None;          
            if (Input.GetKeyDown(_left))
            {
                direction = Direction.Left;
            }
            if (Input.GetKeyDown(_right))
            {
                direction = Direction.Right;
            }
            if (Input.GetKeyDown(_up))
            {
                direction = Direction.Up;
            }
            if (Input.GetKeyDown(_down))
            {
                direction = Direction.Down;
            }
            _characterData._characterBehaviour.Move(direction);
            _characterData._characterBehaviour.TeleportIfOutOfBorder();
            if (Input.GetKey(AxisManager.ESCAPE))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(AxisManager.SPACE))///ТЕСТ Нанесение Урона змейке
            {
                _characterData._characterBehaviour.SetDamage(50);
            }
            if (Input.GetKey( KeyCode.H))///ТЕСТ начесление монет уровня
            {
                Wallet.PutLocalCoins(30);
            }
            if (Input.GetKey(KeyCode.J))///ТЕСТ пакупка(растрата) монет уровня
            {
                Wallet.TakeLocalCoins(50);
            }
            if (Input.GetKey(KeyCode.K))///ТЕСТ начесление монет постоянных
            {
                Wallet.PutWorldCoins(30);
            }
            if (Input.GetKey(KeyCode.L))///ТЕСТ пакупка(растрата) монет постоянных
            {
                Wallet.TakeWorldCoins(50);
            }
        }

        #endregion
    }
}
