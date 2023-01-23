using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity scenes loader manager namespace
/// </summary>
namespace UnityScenesLoaderManager
{
    /// <summary>
    /// A class that describes a state of loading scenes
    /// </summary>
    internal sealed class ScenesLoadingState : IScenesLoadingState
    {
        /// <summary>
        /// Scene loading asynchronous operations
        /// </summary>
        private readonly List<AsyncOperation> sceneLoadingAsynchronousOperations = new();

        /// <summary>
        /// Scene loading asynchronous operations
        /// </summary>
        public IReadOnlyList<AsyncOperation> SceneLoadingAsynchronusOperations => sceneLoadingAsynchronousOperations;

        /// <summary>
        /// Current progress
        /// </summary>
        public float Progress
        {
            get
            {
                float ret = 0.0f;
                if (sceneLoadingAsynchronousOperations.Count > 0)
                {
                    foreach (AsyncOperation scene_loading_async_operations in sceneLoadingAsynchronousOperations)
                    {
                        ret += scene_loading_async_operations.progress;
                    }
                    ret /= sceneLoadingAsynchronousOperations.Count;
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
                foreach (AsyncOperation scene_loading_async_operations in sceneLoadingAsynchronousOperations)
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
                foreach (AsyncOperation scene_loading_async_operations in sceneLoadingAsynchronousOperations)
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

        /// <summary>
        /// Adds the specified scene loading asynchronous operation
        /// </summary>
        /// <param name="sceneLoadingAsynchronousOperation">Scene loading asynchronous operation</param>
        /// <returns>"true" if the specified scene loading asynchronous operation is not contained, otherwise "false"</returns>
        /// <exception cref="ArgumentNullException">When "sceneLoadingAsynchronousOperation" is null</exception>
        bool IScenesLoadingState.AddSceneLoadingAsynchronousOperation(AsyncOperation sceneLoadingAsynchronousOperation)
        {
            if (sceneLoadingAsynchronousOperation == null)
            {
                throw new ArgumentNullException(nameof(sceneLoadingAsynchronousOperation));
            }
            bool ret = !sceneLoadingAsynchronousOperations.Contains(sceneLoadingAsynchronousOperation);
            if (ret)
            {
                sceneLoadingAsynchronousOperations.Add(sceneLoadingAsynchronousOperation);
            }
            return ret;
        }

        /// <summary>
        /// Clears all scene loading asynchronous operations
        /// </summary>
        void IScenesLoadingState.Clear() => sceneLoadingAsynchronousOperations.Clear();
    }
}
