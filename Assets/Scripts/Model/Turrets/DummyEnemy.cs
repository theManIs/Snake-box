using UnityEngine;


namespace Assets.Scripts.Model.Turrets
{
    public class DummyEnemy : MonoBehaviour, IDummyEnemy, IDamageAddressee
    {
        #region Fields

        public ArmorTypes ArmorType = ArmorTypes.Bare;
        private bool _amIDestroyed = false;

        #endregion


        #region IDummyEnemy

        public Vector3 GetPosition() => transform.position;

        public ArmorTypes GetArmorType() => ArmorType;

        public Transform GetTransform() => transform;

        public bool AmIDestroyed() => _amIDestroyed;

        #endregion


        #region IDamageAddressee

        public void RegisterDamage(float damageAmount, ArmorTypes damageType)
        {
            _amIDestroyed = true;

            Destroy(gameObject);
        } 

        #endregion
    }
}