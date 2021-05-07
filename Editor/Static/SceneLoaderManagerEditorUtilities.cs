using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Unity scene loader manager editor namespace
/// </summary>
namespace UnitySceneLoaderManagerEditor
{
    /// <summary>
    /// A class that describes scene loader manager editor utilities
    /// </summary>
    public static class SceneLoaderManagerEditorUtilities
    {
        /// <summary>
        /// Draws scene property
        /// </summary>
        /// <param name="sceneSerializedProperty">Scene sserialized property</param>
        /// <returns>Scene name</returns>
        public static string DrawSceneProperty(SerializedProperty sceneSerializedProperty)
        {
            if (sceneSerializedProperty == null)
            {
                throw new ArgumentNullException(nameof(sceneSerializedProperty));
            }
            return DrawSceneProperty(sceneSerializedProperty.displayName, sceneSerializedProperty);
        }

        /// <summary>
        /// Draws scene property
        /// </summary>
        /// <param name="label">Label</param>
        /// <param name="sceneSerializedProperty">Scene sserialized property</param>
        /// <returns>Scene name</returns>
        public static string DrawSceneProperty(string label, SerializedProperty sceneSerializedProperty)
        {
            if (sceneSerializedProperty == null)
            {
                throw new ArgumentNullException(nameof(sceneSerializedProperty));
            }
            string ret = sceneSerializedProperty.stringValue ?? string.Empty;
            SceneAsset old_scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(ret);
            SceneAsset new_scene = EditorGUILayout.ObjectField(label, old_scene, typeof(SceneAsset), false) as SceneAsset;
            if (old_scene != new_scene)
            {
                ret = AssetDatabase.GetAssetPath(new_scene);
            }
            return ret;
        }

        /// <summary>
        /// Draws something to ask if the specified scene should be added to the build settings, only if that scene is not in the build settings
        /// </summary>
        /// <param name="scenePath">Scene path</param>
        public static void DrawAddSceneToBuildSettingsButtonIfSceneIsNotInBuildSettings(string scenePath)
        {
            if (!string.IsNullOrWhiteSpace(scenePath) && (SceneUtility.GetBuildIndexByScenePath(scenePath) < 0))
            {
                GUILayout.Label("This scene has not been added to your build settings yet.");
                if (GUILayout.Button($"Add scene \"{ Path.GetFileNameWithoutExtension(scenePath) }\" to build settings"))
                {
                    EditorBuildSettingsScene[] old_scenes = EditorBuildSettings.scenes;
                    EditorBuildSettingsScene[] new_scenes = new EditorBuildSettingsScene[old_scenes.Length + 1];
                    Array.Copy(old_scenes, new_scenes, old_scenes.Length);
                    new_scenes[old_scenes.Length] = new EditorBuildSettingsScene(scenePath, true);
                    EditorBuildSettings.scenes = new_scenes;
                }
            }
        }

        /// <summary>
        /// Draws a scene loader manager settings inspector
        /// </summary>
        /// <param name="sceneLoaderManagerSettingsSerializedObject">Scene loader manager settings serialized object</param>
        public static void DrawSceneLoaderManagerSettingsInspector(SerializedObject sceneLoaderManagerSettingsSerializedObject)
        {
            if (sceneLoaderManagerSettingsSerializedObject == null)
            {
                throw new ArgumentNullException(nameof(sceneLoaderManagerSettingsSerializedObject));
            }
            SerializedProperty loading_screen_scene_path_serialized_property = sceneLoaderManagerSettingsSerializedObject.FindProperty("loadingScreenScenePath");
            if (loading_screen_scene_path_serialized_property != null)
            {
                loading_screen_scene_path_serialized_property.stringValue = DrawSceneProperty("Loading Screen Scene", loading_screen_scene_path_serialized_property);
                if (string.IsNullOrWhiteSpace(loading_screen_scene_path_serialized_property.stringValue))
                {
                    GUILayout.Label("Plase assign a loading screen scene if available");
                }
                DrawAddSceneToBuildSettingsButtonIfSceneIsNotInBuildSettings(loading_screen_scene_path_serialized_property.stringValue);
            }
        }
    }
}
