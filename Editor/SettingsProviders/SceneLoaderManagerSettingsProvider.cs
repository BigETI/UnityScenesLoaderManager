using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnitySceneLoaderManager.Objects;

namespace UnitySceneLoaderManagerEditor
{
    internal class SceneLoaderManagerSettingsProvider : SettingsProvider
    {
        private static readonly string defaultAssetsDirectoryPath = "Assets";

        private static readonly string defaultResourcesDirectoryName = "Resources";

        private static readonly string defaultResourcesDirectoryPath = $"{ defaultAssetsDirectoryPath }/{ defaultResourcesDirectoryName }";

        private static readonly string defaultSceneLoaderManagerSettingsDirectoryName = "Settings";

        private static readonly string defaultSceneLoaderManagerSettingsDirectoryPath = $"{ defaultResourcesDirectoryPath }/{ defaultSceneLoaderManagerSettingsDirectoryName }";

        private static readonly string defaultSceneLoaderManagerSettingsAssetName = "SceneLoaderManagerSettings";

        private static readonly string sceneLoaderManagerProjectSettingsLabel = "Scene Loader Manager";

        public SceneLoaderManagerSettingsProvider() :
            base
            (
                "Project/SceneLoaderManager",
                SettingsScope.Project,
                new string[]
                {
                    "Scene",
                    "Loader",
                    "Manager",
                    "Scenes,",
                    "Load",
                    "Loading",
                    "Manage",
                    "Management"
                }
            )
        {
            label = sceneLoaderManagerProjectSettingsLabel;
        }

        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            SceneLoaderManagerSettingsObjectScript settings = null;
            try
            {
                settings = Resources.Load<SceneLoaderManagerSettingsObjectScript>($"{ defaultSceneLoaderManagerSettingsDirectoryName }/{ defaultSceneLoaderManagerSettingsAssetName }");
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            if (settings)
            {
                SerializedObject settings_serialized_object = new SerializedObject(settings);
                settings_serialized_object.Update();
                SceneLoaderManagerEditorUtilities.DrawSceneLoaderManagerSettingsInspector(settings_serialized_object);
                settings_serialized_object.ApplyModifiedPropertiesWithoutUndo();
            }
            else
            {
                if (GUILayout.Button($"Create new scene loader manager settings asset"))
                {
                    try
                    {
                        string directory_path = $"./{ defaultResourcesDirectoryPath }";
                        if (!Directory.Exists(directory_path))
                        {
                            AssetDatabase.CreateFolder(defaultAssetsDirectoryPath, defaultResourcesDirectoryName);
                        }
                        directory_path = $"./{ defaultSceneLoaderManagerSettingsDirectoryPath }";
                        if (!Directory.Exists(directory_path))
                        {
                            AssetDatabase.CreateFolder(defaultResourcesDirectoryPath, defaultSceneLoaderManagerSettingsDirectoryName);
                        }
                        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SceneLoaderManagerSettingsObjectScript>(), Path.Combine(defaultSceneLoaderManagerSettingsDirectoryPath, $"{ defaultSceneLoaderManagerSettingsAssetName }.asset").Replace('\\', '/'));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
        }

        [SettingsProviderGroup]
        internal static SettingsProvider[] FetchGenericSettingsProviderList() => new SettingsProvider[] { new SceneLoaderManagerSettingsProvider() };
    }
}
