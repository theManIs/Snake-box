using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace BottomlessCloset
{
    public sealed class MoveController : IExecute, IListenerScreen
    {
        #region Fields
        
        private List<ItemBehaviour> _itemBehaviours;
        private CameraServices _cameraServices;
        private PhysicsService _physicsService;
        private Vector3 _startPosition;
        private Vector2 _cursorPosition;
        private ItemBehaviour _selectItem;
        private float _startPositionX;
        private float _startPositionY;
        private bool _isDrag;
        private bool _isActive;
        
        #endregion

        
        #region ClassLifeCycles

        public MoveController()
        {
            _itemBehaviours = ItemExtensions.Items;
            _cameraServices = Services.Instance.CameraServices;
            _physicsService = Services.Instance.PhysicsService;
            ScreenInterface.GetInstance().AddObserver(ScreenType.GameMenu, this);
        }
        
        #endregion  
        
        
        #region IExecute

        public void Execute()
        {
            if (!_isActive) { return; }
            
            if (_isDrag)
            {
                OnDrag();
                if (Input.GetMouseButtonUp(0))
                {
                    OnPointerUp();
                }
                
                if (Input.GetMouseButtonDown(1))
                {
                    if (_selectItem)
                    {
                        _selectItem.ItemPhysics.MoveRotation();
                    }
                }
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                _cursorPosition.x = GetMousePosition().x;
                _cursorPosition.y = GetMousePosition().y;
                var idObject = _physicsService.GetIdObject(_cursorPosition);
                if (idObject != -1)
                {
                    _selectItem = _itemBehaviours.SingleOrDefault(behaviour => behaviour.gameObject.GetInstanceID() == idObject);
                    if (_selectItem)
                    {
                        OnPointerDown();
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void OnDrag()
        {
            _selectItem.ItemPhysics.MovePosition(
                new Vector3(GetMousePosition().x - _startPositionX, GetMousePosition().y - _startPositionY, 0));
            _selectItem.SetColor(!_selectItem.ItemPhysics.IsCollision
                ? Data.Instance.ItemData.SelectColor
                : Data.Instance.ItemData.CollisionColor);
        }

        private void OnPointerDown()
        {
            _isDrag = true;
            _startPosition = _selectItem.transform.position;
            foreach (var item in _itemBehaviours)
            {
                item.DisablePhysics(_selectItem.gameObject.GetInstanceID());
            }

            _startPositionX = GetMousePosition().x - _selectItem.transform.localPosition.x;
            _startPositionY = GetMousePosition().y - _selectItem.transform.localPosition.y;
            _selectItem.SetColor(Data.Instance.ItemData.SelectColor);
        }

        private void OnPointerUp()
        {
            _isDrag = false;
            if (_selectItem.ItemPhysics.IsCollision)
            {
                _selectItem.transform.position = _startPosition;
            }
            
            foreach (var item in _itemBehaviours)
            {
                item.EnablePhysics(_selectItem.gameObject.GetInstanceID());
            }

            _selectItem.SetDefaultColor();
            _selectItem = null;
        }

        private Vector3 GetMousePosition()
        {
            return _cameraServices.CameraMain.ScreenToWorldPoint(Input.mousePosition);
        }
        
        #endregion
        
        

        #region IListenerScreen

        public void ShowScreen()
        {
            _isActive = true;
        }

        public void HideScreen()
        {
            _isActive = false;
        }

        #endregion
    }
}
