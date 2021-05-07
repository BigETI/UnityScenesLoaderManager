/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// Used to invoke when scenes have been loaded
    /// </summary>
    /// <param name="scenesLoadingState">Scenes loading state</param>
    public delegate void ScenesLoadedDelegate(IScenesLoadingState scenesLoadingState);
}
