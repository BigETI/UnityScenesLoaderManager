using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Unity scene loader manager controllers namespace
/// </summary>
namespace UnitySceneLoaderManager.Controllers
{
    /// <summary>
    /// A class that describes a scene loader manager controller script
    /// </summary>
    public class SceneLoaderManagerControllerScript : MonoBehaviour, ISceneLoaderManagerController
    {
        /// <summary>
        /// On scene load started
        /// </summary>
        [SerializeField]
        private UnityEvent onScenesLoadStarted = default;

        /// <summary>
        /// On scene loaded
        /// </summary>
        [SerializeField]
        private UnityEvent onScenesLoaded = default;

        /// <summary>
        /// Are all scenes loaded
        /// </summary>
        private bool areAllScenesLoaded = true;

        /// <summary>
        /// Gets invoked when scenes loading process has been started
        /// </summary>
        public event ScenesLoadStartedDelegate OnScenesLoadStarted;

        /// <summary>
        /// Gets invoked when scenes have been loaded
        /// </summary>
        public event ScenesLoadedDelegate OnScenesLoaded;

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            bool are_all_scenes_loaded = SceneLoaderManager.CurrentScenesLoadingState.AreAllScenesLoaded;
            if (areAllScenesLoaded != are_all_scenes_loaded)
            {
                areAllScenesLoaded = are_all_scenes_loaded;
                if (areAllScenesLoaded)
                {
                    if (onScenesLoaded != null)
                    {
                        onScenesLoaded.Invoke();
                    }
                    OnScenesLoadStarted?.Invoke(SceneLoaderManager.CurrentScenesLoadingState);
                }
                else
                {
                    if (onScenesLoadStarted != null)
                    {
                        onScenesLoadStarted.Invoke();
                    }
                    OnScenesLoaded?.Invoke(SceneLoaderManager.CurrentScenesLoadingState);
                }
            }
        }
    }
}
