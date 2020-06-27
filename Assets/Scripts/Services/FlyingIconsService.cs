using System;
using UnityEngine;

namespace Snake_box
{
    public class FlyingIconsService
    {
        public event Action<FlyingIcon> FlyingIconAdded;

        private const float BLOCK_AND_TURRET_ICON_SCALE = 0.7f;

        private readonly Transform _flyingCoinsDestination = GameObject.Find("Flying Coins Destination").transform;
        private readonly Transform _flyingBlocksAndTurretsStart = GameObject.Find("Flying Blocks and Turrets Start").transform;

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

        public void CreateFlyingBlock() => CreateFlyingIcon(Data.Instance.SpriteDictonary.GetSprite("block"), _flyingBlocksAndTurretsStart.position, 
            Services.Instance.LevelService.CharacterBehaviour.Player.transform, BLOCK_AND_TURRET_ICON_SCALE);

        public void CreateFlyingTurret() => CreateFlyingIcon(Data.Instance.SpriteDictonary.GetSprite("simple turret"), _flyingBlocksAndTurretsStart.position,
            Services.Instance.LevelService.CharacterBehaviour.Player.transform, BLOCK_AND_TURRET_ICON_SCALE);
    }

}