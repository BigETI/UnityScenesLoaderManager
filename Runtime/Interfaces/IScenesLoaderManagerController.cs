using UnityPatterns;

/// <summary>
/// Unity scenes loader manager namespace
/// </summary>
namespace UnityScenesLoaderManager
{
    /// <summary>
    /// An interface that represents a scenes loader manager controller
    /// </summary>
    public interface IScenesLoaderManagerController : IController
    {
        /// <summary>
        /// Gets invoked when scenes loading process has been started
        /// </summary>
        event ScenesLoadStartedDelegate OnScenesLoadStarted;

        /// <summary>
        /// Gets invoked when scenes have been loaded
        /// </summary>
        event ScenesLoadedDelegate OnScenesLoaded;
    }
}
