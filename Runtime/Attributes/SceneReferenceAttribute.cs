using System;
using UnityEngine;

/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// An attribute that describes a field to draw a scene reference
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class SceneReferenceAttribute : PropertyAttribute
    {
        /// <summary>
        /// Is allowed to reference scene without build index
        /// </summary>
        public bool IsAllowedToReferenceSceneWithoutBuildIndex { get; }

        /// <summary>
        /// Constructs a new scene reference attribute
        /// </summary>
        public SceneReferenceAttribute()
        {
            // ...
        }

        /// <summary>
        /// Constructs a new scene reference attribute
        /// </summary>
        /// <param name="isAllowedToReferenceSceneWithoutBuildIndex">Is allowed to reference scene without build index</param>
        public SceneReferenceAttribute(bool isAllowedToReferenceSceneWithoutBuildIndex) => IsAllowedToReferenceSceneWithoutBuildIndex = isAllowedToReferenceSceneWithoutBuildIndex;
    }
}
