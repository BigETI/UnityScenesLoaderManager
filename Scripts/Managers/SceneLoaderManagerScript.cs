using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// Unity scene loader manager managers namespace
/// </summary>
namespace UnitySceneLoaderManager.Managers
{
    /// <summary>
    /// Scene loader manager script
    /// </summary>
    public class SceneLoaderManagerScript : MonoBehaviour
    {
        /// <summary>
        /// On load scene
        /// </summary>
        [SerializeField]
        private UnityEvent onLoadScene = default;

        /// <summary>
        /// On scene loaded
        /// </summary>
        [SerializeField]
        private UnityEvent onSceneLoaded = default;

        /// <summary>
        /// Async operation
        /// </summary>
        public AsyncOperation AsyncOperation { get; private set; }

        /// <summary>
        /// Progress
        /// </summary>
        public float Progress
        {
            get
            {
                return ((AsyncOperation == null) ? 0.0f : AsyncOperation.progress);
            }
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static SceneLoaderManagerScript Instance { get; private set; }

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Load scene
        /// </summary>
        public void LoadScene()
        {
            if (AsyncOperation == null)
            {
                AsyncOperation = SceneManager.LoadSceneAsync(SceneLoaderManager.SceneName);
                if (onLoadScene != null)
                {
                    onLoadScene.Invoke();
                }
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (AsyncOperation != null)
            {
                if (AsyncOperation.isDone)
                {
                    AsyncOperation = null;
                    if (onSceneLoaded != null)
                    {
                        onSceneLoaded.Invoke();
                    }
                }
            }
        }
    }
}
