using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity scenes loader manager namespace
/// </summary>
namespace UnityScenesLoaderManager
{
    /// <summary>
    /// An interface that represents a state of loading scenes
    /// </summary>
    public interface IScenesLoadingState
    {
        /// <summary>
        /// Scene loading asynchronous operations
        /// </summary>
        IReadOnlyList<AsyncOperation> SceneLoadingAsynchronusOperations { get; }

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

        /// <summary>
        /// Adds the specified scene loading asynchronous operation
        /// </summary>
        /// <param name="sceneLoadingAsynchronousOperation">Scene loading asynchronous operation</param>
        /// <returns>"true" if the specified scene loading asynchronous operation is not contained, otherwise "false"</returns>
        /// <exception cref="ArgumentNullException">When "sceneLoadingAsynchronousOperation" is null</exception>
        internal bool AddSceneLoadingAsynchronousOperation(AsyncOperation sceneLoadingAsynchronousOperation);

        /// <summary>
        /// Clears all scene loading asynchronous operations
        /// </summary>
        internal void Clear();
    }
}
