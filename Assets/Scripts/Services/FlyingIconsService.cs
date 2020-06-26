using System;
using UnityEngine;

namespace Snake_box
{
    public class FlyingIconsService
    {
        public event Action<FlyingIcon> FlyingIconAdded;

        public void CreateFlyingIcon(Sprite sprite, Vector3 startPosition, Transform destination)
        {
            FlyingIcon flyingIcon = new FlyingIcon();
            flyingIcon.GameObject = new GameObject("Flying Icon", typeof(SpriteRenderer));
            flyingIcon.Destination = destination;
            Vector3 position = startPosition;
            position.y = 1;
            flyingIcon.GameObject.transform.position = position;
            var euler = flyingIcon.GameObject.transform.eulerAngles;
            euler.x = 90;
            flyingIcon.GameObject.transform.eulerAngles = euler;
            var spriteRenderer = flyingIcon.GameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingLayerName = "Flying Icon";
            FlyingIconAdded.Invoke(flyingIcon);
        }
    }

}