using Snake_box;
using UnityEngine;

public class LoadLevelOnStartup : MonoBehaviour
{
    [SerializeField] private string _levelName;

    private void Start()
    {
        Services.Instance.LevelLoadService.LoadLevel(_levelName);
    }
}
