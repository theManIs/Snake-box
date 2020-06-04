using Snake_box;
using UnityEngine;

public class LoadLevelOnStartup : MonoBehaviour
{
    [SerializeField] private LevelType _levelType;

    private void Start()
    {
        Services.Instance.LevelLoadService.LoadLevel(_levelType);
    }
}
