using System.Collections.Generic;
using UnityPatterns;

/// <summary>
/// Unity scenes loader manager namespace
/// </summary>
namespace UnityScenesLoaderManager
{
    /// <summary>
    /// An interface that represents a scenes loader controller
    /// </summary>
    public interface IScenesLoaderController : IController
    {
        /// <summary>
        /// Scene references
        /// </summary>
        string[] SceneReferences { get; set; }

        /// <summary>
        /// Loads scenes
        /// </summary>
        void LoadScenes();

        /// <summary>
        /// Loads scenes
        /// </summary>
        /// <param name="sceneReferences">Scene references</param>
        void LoadScenes(IReadOnlyList<string> sceneReferences);
    }
}
