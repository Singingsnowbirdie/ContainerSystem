using UnityEditor;
using UnityEngine;

namespace Tools
{
    [CustomEditor(typeof(RepositoriesTool))]
    public class RepositoriesToolEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            RepositoriesTool debugTool = (RepositoriesTool)target;

            if (GUILayout.Button("RESET INVENTORY"))
            {
                debugTool.ResetInventoryRepository();
            }

            EditorGUILayout.Space();

            if (GUILayout.Button("RESET CONTAINERS"))
            {
                debugTool.ResetContainersRepository();
            }

            EditorGUILayout.Space();

            if (GUILayout.Button("RESET ALL"))
            {
                debugTool.ResetAllData();
            }

        }
    }
}

