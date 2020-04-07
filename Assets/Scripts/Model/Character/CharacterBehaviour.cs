using UnityEngine;


namespace ExampleTemplate
{
    public sealed class CharacterBehaviour : MonoBehaviour
    {
        private CharacterData _characterData;

        private void Awake()
        {
            _characterData = Data.Instance.Character;
        }

        public void Move(Vector3 moveDirection)
        {
            transform.Translate(transform.right * moveDirection.x * _characterData.GetSpeed());
            transform.Translate(transform.up * moveDirection.y * _characterData.GetSpeed());
        }
    }
}
