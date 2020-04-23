using UnityEngine;
using UnityEngine.SceneManagement;


namespace Snake_box
{
    public sealed class LevelService : Service
    {
        #region Fields

        private int _currentLevel;
        private LevelData _levelData;
        private GameObject _target;
        private GameObject _spawn;


        #endregion


        #region Properties

        public int CurrentLevel => _currentLevel;
        public GameObject Target => _target;
        public GameObject Spawn => _spawn;

        #endregion

        #region ClassLifeCycles

        public LevelService()
        {
            _levelData = Data.Instance.LevelData;
            FindGameObject();
        }


        #endregion


        #region Methods
        
        public void LoadLevel(int lvl)
        {
            _currentLevel = lvl;
            SceneManager.LoadScene(_levelData.Level[lvl].name);
            FindGameObject();
        }

        public void LoadMenu()
        {
            _currentLevel = -1;
            SceneManager.LoadScene(Data.Instance.LevelData.Menu.name);
        }

        public void EndLevel()
        {
            //TODO добавить сохранение прогресса, перед завершением уровня
        }

        private void FindGameObject()
        {
            _target = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Target));
            _spawn = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Spawn));
        }

        #endregion

    }
}
