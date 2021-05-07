using UnityEditor;
using UnitySceneLoaderManager.Objects;

namespace UnitySceneLoaderManagerEditor.EditorScripts
{
    [CustomEditor(typeof(SceneLoaderManagerSettingsObjectScript))]
    internal class SceneLoaderManagerSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SceneLoaderManagerEditorUtilities.DrawSceneLoaderManagerSettingsInspector(serializedObject);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
