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
        private KeyCode _h = KeyCode.H;
        private KeyCode _j = KeyCode.J;
        private KeyCode _k = KeyCode.K;
        private KeyCode _l = KeyCode.L;

        private readonly CharacterData _characterData;
#if UNITY_IOS || UNITY_ANDROID
        private float _minDistanceForSwipe = 20;

        private Vector2 _fingerDownPosition;
        private Vector2 _fingerUpPosition;

        private Vector2 _fingerMovement => _fingerUpPosition - _fingerDownPosition;
#endif
        #endregion

        public InputController()
        {
            _characterData = Data.Instance.Character;           
        }

        #region IExecute

        public void Execute()
        {
            Direction direction = Direction.None;
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR || UNITY_WSA
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
#endif
#if UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];
                switch(touch.phase)
                {
                    case TouchPhase.Began:
                        _fingerDownPosition = touch.position;
                        _fingerUpPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Ended:
                        _fingerUpPosition = touch.position;
                        if(_fingerMovement.sqrMagnitude >= _minDistanceForSwipe * _minDistanceForSwipe)
                        {
                            if(Mathf.Abs(_fingerMovement.x) > Mathf.Abs(_fingerMovement.y))
                            {
                                if (_fingerMovement.x > 0)
                                    direction = Direction.Right;
                                else
                                    direction = Direction.Left;
                            }
                            else
                            {
                                if (_fingerMovement.y > 0)
                                    direction = Direction.Up;
                                else
                                    direction = Direction.Down;
                            }
                        }
                        break;
                }
            }
#endif
            _characterData._characterBehaviour.Move(direction);
            if (Input.GetKey(AxisManager.ESCAPE))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(AxisManager.SPACE))///ТЕСТ Нанесение Урона змейке
            {
                _characterData._characterBehaviour.SetDamage(50);
            }
            if (Input.GetKey(_h))///ТЕСТ начесление монет уровня
            {
                Wallet.PutLocalCoins(30);
            }
            if (Input.GetKey(_j))///ТЕСТ пакупка(растрата) монет уровня
            {
                Wallet.TakeLocalCoins(50);
            }
            if (Input.GetKey(_k))///ТЕСТ начесление монет постоянных
            {
                Wallet.PutWorldCoins(30);
            }
            if (Input.GetKey(_l))///ТЕСТ пакупка(растрата) монет постоянных
            {
                Wallet.TakeWorldCoins(50);
            }
        }

#endregion
    }
}
