using System;
using UnityEngine;

namespace Snake_box
{
    public class LevelLoadService : Service
    {
        public event Action LevelLoaded;
        public event Action LevelUnloaded;

        private GameObject _currentLevel;

        public void LoadLevel(LevelType levelType)
        {
            if (_currentLevel != null)
            {
                GameObject.Destroy(_currentLevel);
                LevelUnloaded?.Invoke();
            }
            _currentLevel = GameObject.Instantiate(Data.Instance.LevelPrefabs[levelType]);
            Services.Instance.LevelService.CurrentLevel = levelType;
            Time.timeScale = 1;
            LevelLoaded?.Invoke();
        }
    } 
}
