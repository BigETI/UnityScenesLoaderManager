using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnitySceneLoaderManager.Objects;

/// <summary>
/// Unity scene loader manager editor namespace
/// </summary>
namespace UnitySceneLoaderManagerEditor
{
    /// <summary>
    /// A class that provides scene loader manager settings
    /// </summary>
    internal class SceneLoaderManagerSettingsProvider : SettingsProvider, ISceneLoaderManagerSettingsProvider
    {
        /// <summary>
        /// Default assets directory path
        /// </summary>
        private static readonly string defaultAssetsDirectoryPath = "Assets";

        /// <summary>
        /// Default resources directory name
        /// </summary>
        private static readonly string defaultResourcesDirectoryName = "Resources";

        /// <summary>
        /// Default resources directory path
        /// </summary>
        private static readonly string defaultResourcesDirectoryPath = $"{ defaultAssetsDirectoryPath }/{ defaultResourcesDirectoryName }";

        /// <summary>
        /// Default settings directory name
        /// </summary>
        private static readonly string defaultSettingsDirectoryName = "Settings";

        /// <summary>
        /// Default settings directory path
        /// </summary>
        private static readonly string defaultSettingsDirectoryPath = $"{ defaultResourcesDirectoryPath }/{ defaultSettingsDirectoryName }";

        /// <summary>
        /// Default scene loader manager settings asset name
        /// </summary>
        private static readonly string defaultSceneLoaderManagerSettingsAssetName = "SceneLoaderManagerSettings";

        /// <summary>
        /// Scene loader manager project settings label
        /// </summary>
        private static readonly string sceneLoaderManagerProjectSettingsLabel = "Scene Loader Manager";

        /// <summary>
        /// Constructs a scene loader manager settings provider
        /// </summary>
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

        /// <summary>
        /// Gets invoked when project settings GUI is being drawn
        /// </summary>
        /// <param name="searchContext">Search context</param>
        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            SceneLoaderManagerSettingsObjectScript settings = null;
            try
            {
                settings = Resources.Load<SceneLoaderManagerSettingsObjectScript>($"{ defaultSettingsDirectoryName }/{ defaultSceneLoaderManagerSettingsAssetName }");
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
                        directory_path = $"./{ defaultSettingsDirectoryPath }";
                        if (!Directory.Exists(directory_path))
                        {
                            AssetDatabase.CreateFolder(defaultResourcesDirectoryPath, defaultSettingsDirectoryName);
                        }
                        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<SceneLoaderManagerSettingsObjectScript>(), Path.Combine(defaultSettingsDirectoryPath, $"{ defaultSceneLoaderManagerSettingsAssetName }.asset").Replace('\\', '/'));
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e);
                    }
                }
            }
        }

        /// <summary>
        /// Fetches scene loader manager settings providers
        /// </summary>
        /// <returns>Scene loader manager settings providers</returns>
        [SettingsProviderGroup]
#pragma warning disable IDE0051 // Remove unused private member
        private static SettingsProvider[] FetchSceneLoaderManagerSettingsProviders() => new SettingsProvider[] { new SceneLoaderManagerSettingsProvider() };
#pragma warning restore IDE0051 // Remove unused private member
    }
}
