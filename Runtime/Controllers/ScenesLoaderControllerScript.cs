using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPatterns.Controllers;

/// <summary>
/// Unity scenes loader manager controllers namespace
/// </summary>
namespace UnityScenesLoaderManager.Controllers
{
    /// <summary>
    /// A class that describes a scenes loader controller script
    /// </summary>
    public sealed class ScenesLoaderControllerScript : AControllerScript, IScenesLoaderController
    {
        /// <summary>
        /// Scene references
        /// </summary>
        [SerializeField]
        [SceneReference]
        [InspectorName("Scenes")]
        private string[] sceneReferences;

        /// <summary>
        /// Is loading scenes additively
        /// </summary>
        [SerializeField]
        private bool isLoadingAdditively;

        /// <summary>
        /// Scene references
        /// </summary>
        public string[] SceneReferences
        {
            get => sceneReferences ?? Array.Empty<string>();
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                sceneReferences = (string[])value.Clone();
            }
        }

        /// <summary>
        /// Is loading scenes additively
        /// </summary>
        public bool IsLoadingAdditively
        {
            get => isLoadingAdditively;
            set => isLoadingAdditively = value;
        }

        /// <summary>
        /// Loads scenes
        /// </summary>
        public void LoadScenes() => LoadScenes(sceneReferences, isLoadingAdditively);

        /// <summary>
        /// Loads the specified scenes
        /// </summary>
        /// <param name="sceneReferences">Scene references</param>
        /// <param name="isLoadingAdditively">Is loading scenes additively</param>
        public void LoadScenes(IReadOnlyList<string> sceneReferences, bool isLoadingAdditively) =>
            ScenesLoaderManager.LoadScenes(sceneReferences, isLoadingAdditively);
    }
}
