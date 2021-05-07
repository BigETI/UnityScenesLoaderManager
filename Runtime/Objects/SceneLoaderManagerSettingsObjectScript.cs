using System;
using UnityEngine;

/// <summary>
/// Unity scene loader manager objects namespace
/// </summary>
namespace UnitySceneLoaderManager.Objects
{
    /// <summary>
    /// A class that describes a scene loader manager settings object script
    /// </summary>
    public class SceneLoaderManagerSettingsObjectScript : ScriptableObject, ISceneLoaderManagerSettingsObject
    {
        /// <summary>
        /// Loading screen scene path
        /// </summary>
        [SerializeField]
        private string loadingScreenScenePath;

        /// <summary>
        /// Loading screen scene path
        /// </summary>
        public string LoadingScreenScenePath
        {
            get => loadingScreenScenePath ?? string.Empty;
            set => loadingScreenScenePath = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
