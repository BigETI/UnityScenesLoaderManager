using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Unity scenes loader manager namespace
/// </summary>
namespace UnityScenesLoaderManager
{
    /// <summary>
    /// A class that describes a scenes loader manager
    /// </summary>
    public static class ScenesLoaderManager
    {
        /// <summary>
        /// Current scenes loading state
        /// </summary>
        public static IScenesLoadingState CurrentScenesLoadingState { get; private set; } = new ScenesLoadingState();

        /// <summary>
        /// Loads the specified scene
        /// </summary>
        /// <param name="sceneName">Scene name</param>
        /// <param name="isLoadingAdditively">Is loading additively</param>
        /// <returns>Scenes loading state</returns>
        public static IScenesLoadingState LoadScene(string sceneName, bool isLoadingAdditively)
        {
            if (string.IsNullOrWhiteSpace(sceneName))
            {
                throw new ArgumentNullException(nameof(sceneName));
            }
            return isLoadingAdditively ? LoadScenesAdditively(sceneName) : LoadScenes(sceneName);
        }

        /// <summary>
        /// Loads all specified scenes
        /// </summary>
        /// <param name="sceneNames">Scene names</param>
        /// <param name="isLoadingAdditively">Is loading additively</param>
        /// <returns>Scenes loading state</returns>
        public static IScenesLoadingState LoadScenes(IReadOnlyList<string> sceneNames, bool isLoadingAdditively)
        {
            if (sceneNames == null)
            {
                throw new ArgumentNullException(nameof(sceneNames));
            }
            if (sceneNames.Count <= 0)
            {
                throw new ArgumentException("Specified scene names need to contain at least one entry.", nameof(sceneNames));
            }
            foreach (string scene_name in sceneNames)
            {
                if (scene_name == null)
                {
                    throw new ArgumentException($"Argument \"{nameof(sceneNames)}\" contains null.", nameof(sceneNames));
                }
                else
                {
                    Scene scene = SceneManager.GetSceneByName(scene_name);
                    if (!scene.IsValid())
                    {
                        throw new ArgumentException($"Scene \"{nameof(scene_name)}\" is not valid.", nameof(sceneNames));
                    }
                }
            }
            if (!isLoadingAdditively)
            {
                CurrentScenesLoadingState.Clear();
            }
            bool is_first = true;
            foreach (string scene_name in sceneNames)
            {
                CurrentScenesLoadingState.AddSceneLoadingAsynchronousOperation
                (
                    SceneManager.LoadSceneAsync(scene_name, (is_first && !isLoadingAdditively) ? LoadSceneMode.Single : LoadSceneMode.Additive)
                );
                is_first = false;
            }
            return CurrentScenesLoadingState;
        }

        /// <summary>
        /// Loads all specified scenes
        /// </summary>
        /// <param name="sceneNames">Scene names</param>
        /// <returns>Scenes loading state</returns>
        public static IScenesLoadingState LoadScenes(params string[] sceneNames) => LoadScenes(sceneNames, false);

        /// <summary>
        /// Loads all specified scenes additively
        /// </summary>
        /// <param name="sceneNames">Scene names</param>
        /// <returns>Scenes loading state</returns>
        public static IScenesLoadingState LoadScenesAdditively(params string[] sceneNames) => LoadScenes(sceneNames, true);
    }
}
