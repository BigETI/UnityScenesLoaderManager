﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// An interface that represents a scene loader manager settings object
    /// </summary>
    public interface ISceneLoaderManagerSettingsObject
    {
        /// <summary>
        /// Loading screen scene path
        /// </summary>
        string LoadingScreenScenePath { get; set; }
    }
}
