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
    public class ScenesLoaderControllerScript : AControllerScript, IScenesLoaderController
    {
        /// <summary>
        /// Scene references
        /// </summary>
        [SerializeField]
        [SceneReference]
        [InspectorName("Scenes")]
        private string[] sceneReferences;

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
        /// Loads scenes
        /// </summary>
        public void LoadScenes() => LoadScenes(sceneReferences);

        /// <summary>
        /// Loads scenes
        /// </summary>
        /// <param name="sceneReferences">Scene references</param>
        public void LoadScenes(IReadOnlyList<string> sceneReferences) => ScenesLoaderManager.LoadScenes(sceneReferences);
    }
}
