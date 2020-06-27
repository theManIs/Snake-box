using System;
using UnityEngine;

namespace Snake_box
{
    public class FlyingIconsService
    {
        public event Action<FlyingIcon> FlyingIconAdded;

        private readonly Transform _flyingCoinsDestination = GameObject.Find("Flying Coins Destination").transform;

        public void CreateFlyingIcon(Sprite sprite, Vector3 startPosition, Transform destination, float scale = 1f)
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
            flyingIcon.GameObject.transform.localScale = Vector3.one * scale;
            var spriteRenderer = flyingIcon.GameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingLayerName = "Flying Icon";
            FlyingIconAdded.Invoke(flyingIcon);
        }

        public void CreateFlyingMoney(Vector3 startPosition) => CreateFlyingIcon(Data.Instance.SpriteDictonary.GetSprite("money") , startPosition, _flyingCoinsDestination);
    }

}