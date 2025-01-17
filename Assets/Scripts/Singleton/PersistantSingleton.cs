using UnityEngine;

namespace Singleton
{
    public class PersistantSingleton<T> : MonoBehaviour where T : Component
    {
        public bool AutoUnparentOnAwake = true;

        protected static T instance;
        
        public static bool HasInstance => instance != null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        var obj = new GameObject(typeof(T).Name + " Auto-Generated");
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        private void InitializeSingleton()
        {
            if(!Application.isPlaying) return;

            if (AutoUnparentOnAwake)
            {
                transform.SetParent(null);
            }

            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (instance != this)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}