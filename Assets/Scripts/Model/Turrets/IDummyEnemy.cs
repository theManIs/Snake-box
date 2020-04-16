using UnityEngine;


namespace Assets.Scripts.Model.Turrets
{
    public interface IDummyEnemy
    {
        #region Methods

        Vector2 GetPosition();

        ArmorTypes GetArmorType();

        #endregion
    }
}