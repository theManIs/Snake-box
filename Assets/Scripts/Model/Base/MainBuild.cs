using System;
using Snake_box;
using UnityEngine;
using Object = UnityEngine.Object;


namespace ExampleTemplate
{
    public class MainBuild : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _hp;
        private LevelService _levelService;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _levelService = Services.Instance.LevelService;
        }

        #endregion
        
        #region Methods

        public void GetDamage(float damage = 1)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
                _levelService.IsTargetDestroed = true;
                _levelService.EndLevel();
            }
        }

        #endregion
    }
}
