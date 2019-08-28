using UnityEngine.SceneManagement;
using UnitySceneLoaderManager.Managers;

/// <summary>
/// Unity scene loader manager namespace
/// </summary>
namespace UnitySceneLoaderManager
{
    /// <summary>
    /// Scene loader manager class
    /// </summary>
    public static class SceneLoaderManager
    {
        /// <summary>
        /// Scene name
        /// </summary>
        public static string SceneName { get; private set; } = "IntroScene";

        /// <summary>
        /// Progress
        /// </summary>
        public static float Progress
        {
            get
            {
                return ((LoadingScreenManagerScript.Instance == null) ? 0.0f : LoadingScreenManagerScript.Instance.Progress);
            }
        }

        /// <summary>
        /// Load scene
        /// </summary>
        /// <param name="sceneName">Scene name</param>
        public static void LoadScene(string sceneName)
        {
            if (sceneName != null)
            {
                SceneName = sceneName;
                if (SceneLoaderManagerScript.Instance == null)
                {
                    SceneManager.LoadScene("LoadingScreenScene");
                }
                else
                {
                    SceneLoaderManagerScript.Instance.LoadScene();
                }
            }
        }
    }
}
