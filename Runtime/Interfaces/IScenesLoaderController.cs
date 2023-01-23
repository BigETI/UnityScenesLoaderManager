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
        /// Is loading scenes additively
        /// </summary>
        bool IsLoadingAdditively { get; set; }

        /// <summary>
        /// Loads scenes
        /// </summary>
        void LoadScenes();

        /// <summary>
        /// Loads the specified scenes
        /// </summary>
        /// <param name="sceneReferences">Scene refereneces</param>
        /// <param name="isLoadingAdditively">Is loading scenes additively</param>
        void LoadScenes(IReadOnlyList<string> sceneReferences, bool isLoadingAdditively);
    }
}
