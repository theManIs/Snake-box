using Snake_box;
using UnityEngine;

public class LoadLevelOnStartup : MonoBehaviour
{
    [SerializeField] private string _name;

    private void Start()
    {
        Services.Instance.LevelLoadService.LoadLevel(name);
    }
}
