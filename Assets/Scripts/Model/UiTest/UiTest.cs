using Snake_box;
using UnityEngine;


public class UiTest : MonoBehaviour
{
    private LevelService _levelService;

    private void Awake()
    {
        _levelService = Services.Instance.LevelService;
    }

    public void LoadLevel(int lvl)
    {
        _levelService.LoadLevel(lvl);
    }

}
