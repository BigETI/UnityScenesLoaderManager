using UnityEditor;
using UnitySceneLoaderManager.Objects;

/// <summary>
/// Unity scene loader manager editor editor scripts namespace
/// </summary>
namespace UnitySceneLoaderManagerEditor.EditorScripts
{
    /// <summary>
    /// A class that describes a scene loader manager settings editor
    /// </summary>
    [CustomEditor(typeof(SceneLoaderManagerSettingsObjectScript))]
    internal class SceneLoaderManagerSettingsEditor : Editor, ISceneLoaderManagerSettingsEditor
    {
        /// <summary>
        /// Gets invoked when inspector is being drawn
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SceneLoaderManagerEditorUtilities.DrawSceneLoaderManagerSettingsInspector(serializedObject);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
