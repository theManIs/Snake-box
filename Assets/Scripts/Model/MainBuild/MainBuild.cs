using UnityEngine;


namespace Snake_box
{
    public class MainBuild 
    {
        #region Fields

        private MainBuildData _mainBuildData;
        private GameObject _build;
        public float _hp;

        #endregion   


        #region ClassLifeCycle

        public MainBuild()
        {
            _mainBuildData = Data.Instance.MainBuildData;
            _hp = _mainBuildData.Hp;
            _build = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Target));
        }

        #endregion
        

        #region Methods

        public void GetDamage(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Object.Destroy(_build);
                Services.Instance.LevelService.IsTargetDestroed = true;
                Services.Instance.LevelService.EndLevel();
            }
        }        

        #endregion
    }
}
