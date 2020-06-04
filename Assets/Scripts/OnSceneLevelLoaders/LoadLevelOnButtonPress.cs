using UnityEngine;

namespace Snake_box
{
    public class LoadLevelOnButtonPress : MonoBehaviour
    {
        [SerializeField] private LevelType _levelType;

        public void Load()
        {
            if(Application.isPlaying)
                Services.Instance.LevelLoadService.LoadLevel(_levelType);
        }
    } 
}
