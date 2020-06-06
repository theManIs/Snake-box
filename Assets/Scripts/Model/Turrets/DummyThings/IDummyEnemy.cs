using UnityEngine;


namespace Snake_box
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