using System.Collections.Generic;
using UnityEngine;

namespace Snake_box
{
	public class FlyingIconsController : IExecute, IInitialization, ICleanUp
	{
        private const float FLYING_ICONS_SPEED = 10;

		private List<FlyingIcon> _flyingIcons = new List<FlyingIcon>();

        #region IExecute

        public void Execute()
        {
            float translationDistance = FLYING_ICONS_SPEED * Time.deltaTime;
            var flyingIcons = _flyingIcons.ToArray();
            foreach(FlyingIcon icon in flyingIcons)
            {
                Vector3 direction = icon.Destination.position - icon.GameObject.transform.position;
                if(direction.sqrMagnitude <= translationDistance * translationDistance)
                {
                    Object.Destroy(icon.GameObject);
                    _flyingIcons.Remove(icon);
                }
                else
                {
                    //var translation = (direction.normalized * translationDistance);
                    //var position = icon.GameObject.transform.position;
                    //position.x += translation.x;
                    //position.z += translation.z;
                    //icon.GameObject.transform.position = position;
                    icon.GameObject.transform.Translate(direction.normalized * translationDistance, Space.World);
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

        #endregion
    }
}
