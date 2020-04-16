using UnityEngine;


namespace Assets.Scripts.Model.Turrets
{
    public class DummyEnemy : MonoBehaviour, IDummyEnemy, IDamageAddressee
    {
        #region Fields

        public Vector2 DescartesPosition = Vector2.zero;
        public ArmorTypes ArmorType = ArmorTypes.Bare;

        #endregion

        #region MonoBehaviour

        public void Start()
        {
            DescartesPosition = transform.position;
        }

        #endregion


        #region IDummyEnemy

        public Vector2 GetPosition() => DescartesPosition;
        public ArmorTypes GetArmorType() => ArmorType;

        #endregion

        public void RegisterDamage(float damageAmount, ArmorTypes damageType)
        {
            throw new System.NotImplementedException("RegisterDamage has not been implemented yet.");
        }
    }
}