/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// An interface that represents a scene loader manager controller
    /// </summary>
    public interface ISceneLoaderManagerController
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
