using UnityEngine;

namespace Snake_box
{
    public class Finger : MonoBehaviour
    {
        [SerializeField] private float _y;
        [SerializeField] private Vector2 _hotspot;

        private void Update()
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.y = _y;
            position.x -= _hotspot.x;
            position.z -= _hotspot.y;
            transform.position = position;
        }

        private void OnEnable()
        {
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            Cursor.visible = true;
        }
    }

}