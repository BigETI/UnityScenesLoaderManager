using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnitySceneLoaderManagerEditor
{
    public static class SceneLoaderManagerEditorUtilities
    {
        public static string DrawSceneProperty(SerializedProperty sceneSerializedProperty)
        {
            if (sceneSerializedProperty == null)
            {
                throw new ArgumentNullException(nameof(sceneSerializedProperty));
            }
            return DrawSceneProperty(sceneSerializedProperty.displayName, sceneSerializedProperty);
        }

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
