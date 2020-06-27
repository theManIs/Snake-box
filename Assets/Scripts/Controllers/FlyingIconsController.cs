using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Snake_box
{
	public class FlyingIconsController : IExecute, IInitialization, ICleanUp
	{
        private const float FLYING_ICONS_SPEED = 100;

		private List<FlyingIcon> _flyingIcons = new List<FlyingIcon>();

        #region IExecute

        public void Execute()
        {
            float translationDistance = FLYING_ICONS_SPEED * Time.deltaTime;
            var flyingIcons = _flyingIcons.ToArray();
            foreach(FlyingIcon icon in flyingIcons)
            {
                Vector3 direction = icon.Destination.position - PositionWithY1(icon.GameObject.transform);
                if(direction.sqrMagnitude <= translationDistance * translationDistance)
                {
                    Object.Destroy(icon.GameObject);
                    _flyingIcons.Remove(icon);
                }
                else
                {
                    icon.GameObject.transform.Translate(direction.normalized * translationDistance, Space.World);
                    icon.GameObject.transform.position = new Vector3(icon.GameObject.transform.position.x, 1, icon.GameObject.transform.position.z);
                }

            }
        }

        #endregion

        #region IInitializaton

        public void Initialization()
        {
            Services.Instance.FlyingIconsService.FlyingIconAdded += AddFlyingIconToList;
        }

        #endregion

        #region ICleanUp

        public void Clean()
        {
            Services.Instance.FlyingIconsService.FlyingIconAdded -= AddFlyingIconToList;
            foreach (FlyingIcon icon in _flyingIcons)
            {
                GameObject.Destroy(icon.gameObject);
            }
        }

        #endregion

        #region Methods

        private void AddFlyingIconToList(FlyingIcon flyingIcon) => _flyingIcons.Add(flyingIcon);

        private Vector3 PositionWithY1(Transform transform)
        {
            Vector3 result = transform.position;
            result.y = 1;
            return result;
        }

        #endregion
    }
}
