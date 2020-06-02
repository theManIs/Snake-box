using Snake_box;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LoadLevelOnButtonPress))]
public class LoadLevelOnButtonPressEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Load"))
            ((LoadLevelOnButtonPress)target).Load();
    }
}
