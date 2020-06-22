using UnityEngine;

namespace Snake_box
{
    public sealed class SpikedEnemy : BaseEnemy
    {
        #region PrivateData

        private SpikedEnemyData _data;
        private float _spikeThreshold;
        private float _bonusDamage;

        #endregion


        #region ClassLifeCycle

        public SpikedEnemy() : base(Data.Instance.SpikedEnemy)
        {
            _data = Data.Instance.SpikedEnemy;
            Type = EnemyType.Spiked;
            GetTarget();
            _spikeThreshold = _hp/100*_data.SpikeThreshold;
            _bonusDamage = _data.BonusDamage;
        }

        #endregion


        #region Methods

        protected override void HitCheck()
        {
            Collider[] colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(_transform.position, _meleeHitRange, colliders);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != null)
                {
                    if (colliders[i].CompareTag(TagManager.GetTag(TagType.Target)))
                    {
                        var mainBuilding = colliders[i].GetComponent<MainBuild>();
                        mainBuilding.GetDamage(_damage);
                    }

                    if (_hp < _spikeThreshold)
                    {
                        if (colliders[i].CompareTag(TagManager.GetTag(TagType.Player)))
                        {
                            Services.Instance.LevelService.CharacterBehaviour.SetArmor(_damage);
                        }
                        else if (colliders[i].CompareTag(TagManager.GetTag(TagType.Block)))
                        {
                            Services.Instance.LevelService.CharacterBehaviour.SetDamage(_damage);
                        }
                    }
                    else
                    {
                        if (colliders[i].CompareTag(TagManager.GetTag(TagType.Player)))
                        {
                            Services.Instance.LevelService.CharacterBehaviour.SetDamage(_damage);
                        }
                        else if (colliders[i].CompareTag(TagManager.GetTag(TagType.Block)))
                        {
                            Services.Instance.LevelService.CharacterBehaviour.SetDamage(_damage+_bonusDamage);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
