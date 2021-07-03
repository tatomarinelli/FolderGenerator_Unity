#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FolderGenerator))]
public class FolderGeneratorEditor : Editor
{
    // VARIABLES
    //public string playerManagerInfo = "Describe PlayerManager Script";
    public override void OnInspectorGUI()
    {
        FolderGenerator folderGenerator = (FolderGenerator)target; // target, reserved word for "Object being inspected".
        // EditorGUILayout.HelpBox(playerManager.GetDescription(), MessageType.Info);
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Folder Structure"))
        {
            folderGenerator.GenerateFolders();
        }

    }
}

#endif
