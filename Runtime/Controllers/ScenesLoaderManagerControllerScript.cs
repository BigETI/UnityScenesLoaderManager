using UnityEngine;
using UnityEngine.Events;
using UnityPatterns.Controllers;

/// <summary>
/// Unity scenes loader manager controllers namespace
/// </summary>
namespace UnityScenesLoaderManager.Controllers
{
    /// <summary>
    /// A class that describes a scenes loader manager controller script
    /// </summary>
    public sealed class ScenesLoaderManagerControllerScript : AControllerScript, IScenesLoaderManagerController
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
            bool are_all_scenes_loaded = ScenesLoaderManager.CurrentScenesLoadingState.AreAllScenesLoaded;
            if (areAllScenesLoaded != are_all_scenes_loaded)
            {
                areAllScenesLoaded = are_all_scenes_loaded;
                if (areAllScenesLoaded)
                {
                    if (onScenesLoaded != null)
                    {
                        onScenesLoaded.Invoke();
                    }
                    OnScenesLoadStarted?.Invoke(ScenesLoaderManager.CurrentScenesLoadingState);
                }
                else
                {
                    if (onScenesLoadStarted != null)
                    {
                        onScenesLoadStarted.Invoke();
                    }
                    OnScenesLoaded?.Invoke(ScenesLoaderManager.CurrentScenesLoadingState);
                }
            }
        }
    }
}
