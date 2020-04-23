using UnityEngine;
using UnityEngine.SceneManagement;


namespace Snake_box
{
    public sealed class LevelService : Service
    {
        #region PrivateData

        private readonly LevelData _levelData;

        #endregion


        #region Properties

        public GameObject Target { get; private set; }
        public GameObject Spawn { get; private set; }
        public int CurrentLevel { get; private set; }
        public bool IsSpawnNeed { get; set; }
        public bool IsWaveEnded { get; set; }
        public bool IsLevelEnded { get; set; }

        #endregion

        #region ClassLifeCycles

        public LevelService()
        {
            _levelData = Data.Instance.LevelData;
            IsWaveEnded = false;
            IsLevelEnded = false;
            FindGameObject();
            if (SceneManager.GetActiveScene().name != Data.Instance.LevelData.Menu.name)
                IsSpawnNeed = true;
        }


        #endregion


        #region Methods
        
        public void LoadLevel(int lvl)
        {
            CurrentLevel = lvl;
            SceneManager.LoadScene(_levelData.Level[lvl].name);
            FindGameObject();
            IsSpawnNeed = true;
        }

        public void LoadMenu()
        {
            CurrentLevel = -1;
            SceneManager.LoadScene(Data.Instance.LevelData.Menu.name);
        }

        public void EndLevel()
        {
            //TODO добавить сохранение прогресса, перед завершением уровня
        }

        private void FindGameObject()
        {
            Target = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Target));
            Spawn = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Spawn));
        }

        #endregion

    }
}
