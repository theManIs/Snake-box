using UnityEngine;


namespace Snake_box
{
    public class DummyEnemy : MonoBehaviour, IEnemy, IDamageAddressee
    {
        #region Fields

        public ArmorTypes ArmorType = ArmorTypes.Bare;
        private bool _amIDestroyed = false;

        #endregion


        #region IDummyEnemy

        public Vector3 GetPosition() => transform.position;
        public EnemyType GetEnemyType() => EnemyType.Fast;
        public bool IsValidTarget()
        {
            throw new System.NotImplementedException();
        }

        public ArmorTypes GetArmorType() => ArmorType;

        public void OnUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void Spawn(Vector3 position)
        {
            throw new System.NotImplementedException();
        }

        public Transform GetTransform() => transform;

        public bool AmIDestroyed() => _amIDestroyed;

        #endregion


        #region IDamageAddressee

        //todo I should provide ProjectileType instead ArmorType 
        public void RegisterDamage(float damageAmount, ArmorTypes damageType)
        {
            _amIDestroyed = true;

            Destroy(gameObject);
        } 

        #endregion
    }
}