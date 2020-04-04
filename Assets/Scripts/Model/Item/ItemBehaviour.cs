using UnityEngine;


namespace BottomlessCloset
{
    [RequireComponent(typeof(ItemPhysics))]
    public sealed class ItemBehaviour : MonoBehaviour
    {
        #region Fields

        private ItemPhysics _itemPhysics; 
        private Material _material;
        private Color _startColor;

        #endregion


        #region Propertis

        public ItemPhysics ItemPhysics => _itemPhysics;

        #endregion
        

        #region UnityMethods

        private void Start()
        {
            _itemPhysics = GetComponent<ItemPhysics>();
            _material = GetComponent<Renderer>().material;
            _startColor = _material.color;
        }

        #endregion


        #region Methods

        public void EnablePhysics(int gameObjectId)
        {
            ItemPhysics.EnablePhysics(gameObjectId);
        }

        public void DisablePhysics(int gameObjectId)
        {
            ItemPhysics.DisablePhysics(gameObjectId);
        }

        public void SetColor(Color color)
        {
            _material.color = color;
        }

        public void SetDefaultColor()
        {
            _material.color = _startColor;
        }

        #endregion
    }
}
