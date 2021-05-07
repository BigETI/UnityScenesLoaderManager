/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// Used to invoke when loading scenes have been started
    /// </summary>
    /// <param name="scenesLoadingState">Scenes loading state</param>
    public delegate void ScenesLoadStartedDelegate(IScenesLoadingState scenesLoadingState);
}
