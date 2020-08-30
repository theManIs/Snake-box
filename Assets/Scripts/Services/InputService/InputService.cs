using UnityEngine;

namespace Assets.Scripts.Services.InputService
{
    public class InputService
    {
        public KeyCode KeyDownIs()
        {
            KeyCode keyCode = default;

            if (Input.GetKeyDown(KeyCode.F))
            {
                keyCode = KeyCode.F;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                keyCode = KeyCode.C;
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                keyCode = KeyCode.V;
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                keyCode = KeyCode.G;
            }

            return keyCode;
        }

        public bool IsKeysPressed()
        {
            return Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V) ||
                   Input.GetKeyDown(KeyCode.G);
        }
    }
}