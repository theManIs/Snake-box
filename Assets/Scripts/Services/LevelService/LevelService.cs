using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


namespace Snake_box
{
    public sealed class LevelService : Service
    {
        #region Fields

        public List<IEnemy> ActiveEnemies = new List<IEnemy>();
        private readonly LevelData _levelData;

        #endregion


        #region Properties

        public GameObject Target { get; private set; }
        public GameObject Spawn { get; private set; }
        public int CurrentLevel { get; private set; }
        public bool IsSpawnNeed { get; set; }
        public bool IsWaveEnded { get; set; }
        public bool IsLevelSpawnEnded { get; set; }
        public bool IsLevelStarted { get; set; }
        public bool IsTargetDestroed { get; set; }
        public bool IsSnakeAlive { get; set; }

        #endregion


        #region ClassLifeCycles

        public LevelService()
        {
            SceneManager.sceneLoaded += (arg0, mode) => LevelStart(); 
            _levelData = Data.Instance.LevelData;
            IsWaveEnded = false;
            IsLevelSpawnEnded = false;
            IsTargetDestroed = false;
            if (!SceneManager.GetActiveScene().name.Equals(Data.Instance.LevelData.Menu))
                IsSpawnNeed = true;
        }

        #endregion


        #region Methods
        
        public void LoadLevel(int lvl)
        {
            CurrentLevel = lvl;
            SceneManager.LoadScene(_levelData.Level[lvl]);
        }

        public void LoadMenu()
        {
            CurrentLevel = -1;
            SceneManager.LoadScene(Data.Instance.LevelData.Menu);
        }

        public void EndLevel()
        {
            var panel = GameObject.FindWithTag(TagManager.GetTag(TagType.PanelEndLevel));
            panel.transform.GetChild(0).gameObject.SetActive(true);
            panel.GetComponentInParent<GameMenuBehaviour>().GetEndLevelText();
            ActiveEnemies.Clear();
            Data.Instance.TurretData.ClearTurretList();          
            
        }

        private void LevelStart()
        {
            FindGameObject();
            IsLevelStarted = true;
            IsSpawnNeed = true;
            IsWaveEnded = false;
            IsLevelSpawnEnded = false;
            IsTargetDestroed = false;
            if (GameObject.FindObjectOfType<NavMeshSurface>())
            {
                var surface = GameObject.FindObjectOfType<NavMeshSurface>();
                surface.BuildNavMesh();
            }
        }
        public void FindGameObject()
        {
            Target = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Target));
            Spawn = GameObject.FindGameObjectWithTag(TagManager.GetTag(TagType.Spawn));
        }



        #endregion

    }
}
