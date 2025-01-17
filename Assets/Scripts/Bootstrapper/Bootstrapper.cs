using Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bootstrapper
{
    public class Bootstrapper : PersistantSingleton<Bootstrapper>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            Debug.Log("Bootstrapper Initialized");
            SceneManager.LoadSceneAsync("Bootstrapper", LoadSceneMode.Single);
        }
    }
}