using UnityEngine;


namespace Assets.Scripts.Model.Turrets
{
    public abstract class TurretProjectileAbs : MonoBehaviour
    {
        #region Methods

        public abstract ArmorTypes GetArmorType();
        public abstract float GetCarryingDamage();

        public void OnTriggerEnter2D(Collider2D collideInfo)
        {
            IDamageAddressee damageTarget = collideInfo.GetComponent<IDamageAddressee>();


            Debug.Log(collideInfo.gameObject.name);
            Destroy(gameObject);
            Destroy(collideInfo.gameObject, 1);

            damageTarget?.RegisterDamage(GetCarryingDamage(), GetArmorType());
        } 

        #endregion
    }
}