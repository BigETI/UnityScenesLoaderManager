using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// An interface that represents a state of loading scenes
    /// </summary>
    public interface IScenesLoadingState
    {
        /// <summary>
        /// Scene loading asynchronous operations
        /// </summary>
        IReadOnlyList<AsyncOperation> SceneLoadingAsyncOperations { get; }

        /// <summary>
        /// Current progress
        /// </summary>
        float Progress { get; }

        /// <summary>
        /// Are all scenes loaded
        /// </summary>
        bool AreAllScenesLoaded { get; }

        /// <summary>
        /// Is scene activation allowed
        /// </summary>
        bool IsSceneActivationAllowed { get; }
    }
}
