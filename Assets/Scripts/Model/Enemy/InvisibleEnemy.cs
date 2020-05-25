using UnityEngine;

namespace Snake_box
{
    public sealed class InvisibleEnemy : BaseEnemy
    {
        #region PrivateData

        private InvisibleEnemyData _data;
        private MeshRenderer _render;
        private TimeRemaining _setvisible;

        #endregion

        
        #region ClassLifeCycle

        public InvisibleEnemy() : base(Data.Instance.InvisibleEnemy)
        {
            _data = Data.Instance.InvisibleEnemy;
            _setvisible = new TimeRemaining(ImVisible, _data.InvisibleTime);
            Type = EnemyType.Invisible;
            
            GetTarget();
        }

        #endregion


        #region IEnemy

        public override void Spawn()
        {
            base.Spawn();
            _render = _enemyObject.GetComponent<MeshRenderer>();
        }

        #endregion


        #region Methods

        protected override void GetDamage(float damage)
        {
            base.GetDamage(damage);
            _render.enabled = false;
            _isValidTarget = false;
            _setvisible.AddTimeRemaining();
        }

        private void ImVisible()
        {
            _render.enabled = true;
            _isValidTarget = true;
        }

        #endregion
    }
}
