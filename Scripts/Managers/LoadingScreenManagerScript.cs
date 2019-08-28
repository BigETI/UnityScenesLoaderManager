using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Unity scene loader manager managers namespace
/// </summary>
namespace UnitySceneLoaderManager.Managers
{
    /// <summary>
    /// Loading screen manager class
    /// </summary>
    public class LoadingScreenManagerScript : MonoBehaviour
    {
        /// <summary>
        /// Async operation
        /// </summary>
        public AsyncOperation AsyncOperation { get; private set; }

        /// <summary>
        /// Progress
        /// </summary>
        public float Progress => ((AsyncOperation == null) ? 0.0f : AsyncOperation.progress);

        /// <summary>
        /// Instance
        /// </summary>
        public static LoadingScreenManagerScript Instance { get; private set; }

        /// <summary>
        /// On enable
        /// </summary>
        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        /// <summary>
        /// On disable
        /// </summary>
        private void OnDisable()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            AsyncOperation = SceneManager.LoadSceneAsync(SceneLoaderManager.SceneName);
        }
    }
}
