namespace SceneHandler
{
    public class SceneGroupEvents
    {
        public delegate void SceneLoaded(string sceneName);
        public delegate void SceneUnloaded(string sceneName);
        public delegate void SceneGroupLoaded();
        
        public SceneLoaded OnSceneLoaded;
        public SceneUnloaded OnSceneUnloaded;
        public SceneGroupLoaded OnSceneGroupLoaded;
    }
}