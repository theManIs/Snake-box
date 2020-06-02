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
        public string CurrentLevelName { get; set; }
        public bool IsLevelSpawnEnded { get; set; }
        public bool IsTargetDestroed { get; set; }
        public bool IsSnakeAlive { get; set; }

        #endregion


        #region ClassLifeCycles

        public LevelService()
        {
            SceneManager.sceneLoaded += (arg0, mode) => LevelStart(); 
            _levelData = Data.Instance.LevelData;
            IsLevelSpawnEnded = false;
            IsTargetDestroed = false;
            Services.Instance.LevelLoadService.LevelLoaded += LevelStart;
        }

        #endregion


        #region Methods
        
        public void LoadLevel(int lvl)
        {
            SceneManager.LoadScene(_levelData.Level[lvl]);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene(Data.Instance.LevelData.Menu);
        }

        public void EndLevel()
        {
            Wallet.ResetLocalCoins();
            var panel = GameObject.FindWithTag(TagManager.GetTag(TagType.PanelEndLevel));
            panel.transform.GetChild(0).gameObject.SetActive(true);
            panel.GetComponentInParent<GameMenuBehaviour>().GetEndLevelText();
            ActiveEnemies.Clear();
            Data.Instance.TurretData.ClearTurretList();          
            
        }

        private void LevelStart()
        {
            FindGameObject();
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
        }

        #endregion

    }
}
