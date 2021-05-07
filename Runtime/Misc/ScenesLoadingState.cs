using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// A class that describes a state of loading scenes
    /// </summary>
    internal class ScenesLoadingState : IScenesLoadingState
    {
        /// <summary>
        /// Scene loading asynchronous operations
        /// </summary>
        private readonly AsyncOperation[] sceneLoadingAsyncOperations;

        /// <summary>
        /// Scene loading asynchronous operations
        /// </summary>
        public IReadOnlyList<AsyncOperation> SceneLoadingAsyncOperations => sceneLoadingAsyncOperations;

        /// <summary>
        /// A scenes loading state with without any scenes
        /// </summary>
        public static ScenesLoadingState Empty { get; } = new ScenesLoadingState(Array.Empty<AsyncOperation>());

        /// <summary>
        /// Constructs a scenes loading state
        /// </summary>
        /// <param name="sceneLoadingAsyncOperations">Scene loading asynchronous operations</param>
        public ScenesLoadingState(IReadOnlyList<AsyncOperation> sceneLoadingAsyncOperations)
        {
            if (sceneLoadingAsyncOperations == null)
            {
                throw new ArgumentNullException(nameof(sceneLoadingAsyncOperations));
            }
            foreach (AsyncOperation scene_loading_async_operations in sceneLoadingAsyncOperations)
            {
                if (scene_loading_async_operations == null)
                {
                    throw new ArgumentException($"Parameter \"{ nameof(sceneLoadingAsyncOperations) }\" contains null.");
                }
            }
            this.sceneLoadingAsyncOperations = sceneLoadingAsyncOperations.ToArray();
        }

        /// <summary>
        /// Current progress
        /// </summary>
        public float Progress
        {
            get
            {
                float ret = 0.0f;
                if (sceneLoadingAsyncOperations.Length > 0)
                {
                    foreach (AsyncOperation scene_loading_async_operations in sceneLoadingAsyncOperations)
                    {
                        ret += scene_loading_async_operations.progress;
                    }
                    ret /= sceneLoadingAsyncOperations.Length;
                }
                return ret;
            }
        }

        /// <summary>
        /// Are all scenes loaded
        /// </summary>
        public bool AreAllScenesLoaded
        {
            get
            {
                bool ret = true;
                foreach (AsyncOperation scene_loading_async_operations in sceneLoadingAsyncOperations)
                {
                    if (!scene_loading_async_operations.isDone)
                    {
                        ret = false;
                        break;
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// Is scene activation allowed
        /// </summary>
        public bool IsSceneActivationAllowed
        {
            get
            {
                bool ret = true;
                foreach (AsyncOperation scene_loading_async_operations in sceneLoadingAsyncOperations)
                {
                    if (!scene_loading_async_operations.allowSceneActivation)
                    {
                        ret = false;
                        break;
                    }
                }
                return ret;
            }
        }
    }
}
