using UnityEngine;


namespace Assets.Scripts.Model.Turrets
{
    public interface IDummyEnemy
    {
        #region Methods

        Vector3 GetPosition();

        ArmorTypes GetArmorType();

        Transform GetTransform();

        bool AmIDestroyed();

        #endregion
    }
}