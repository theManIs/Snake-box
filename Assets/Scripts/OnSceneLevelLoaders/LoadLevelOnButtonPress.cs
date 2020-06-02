using UnityEngine;

namespace Snake_box
{
    public class LoadLevelOnButtonPress : MonoBehaviour
    {
        [SerializeField] private string _levelName;

        public void Load()
        {
            if(Application.isPlaying)
                Services.Instance.LevelLoadService.LoadLevel(_levelName);
        }
    } 
}
