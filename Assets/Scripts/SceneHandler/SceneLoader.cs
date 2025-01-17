using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SceneHandler
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Image loadingBar;
        [SerializeField] private float fillSpeed = 0.5f;
        [SerializeField] private Canvas loadingCanvas;
        [SerializeField] private Camera loadingCamera;
        [SerializeField] private SceneGroup[] sceneGroup;
        
        float targetProgress;
        bool isLoading;
        
        public readonly SceneGroupHandler sceneGroupHandler = new SceneGroupHandler();

        private void Awake()
        {
            sceneGroupHandler.SceneGroupEvents.OnSceneLoaded += sceneName => Debug.Log($"Loaded {sceneName}");
            sceneGroupHandler.SceneGroupEvents.OnSceneUnloaded += sceneName => Debug.Log($"Unloaded {sceneName}");
            sceneGroupHandler.SceneGroupEvents.OnSceneGroupLoaded += () => Debug.Log("Scene Group Loaded");
        }

        private async void Start()
        {
            await LoadSceneGroup(0);
        }

        private void Update()
        {
            if(!isLoading) return;
            
            var currentFillAmount = loadingBar.fillAmount;
            var progressDifference = Mathf.Abs(currentFillAmount - targetProgress);
            
            var dynamicFillSpeed = progressDifference * fillSpeed;
            
            loadingBar.fillAmount = Mathf.Lerp(currentFillAmount, targetProgress, Time.deltaTime * dynamicFillSpeed);
        }

        private async Task LoadSceneGroup(int index)
        {
            loadingBar.fillAmount = 0;
            targetProgress = 1f;

            if (index < 0 || index >= sceneGroup.Length)
            {
                Debug.LogWarning($"Scene Group index {index} is out of range.");
                return;
            }
            
            LoadingProgress progress = new LoadingProgress();
            progress.Progressed += target => targetProgress = Mathf.Max(target, targetProgress);

            EnableLoadingCanvas();
            await sceneGroupHandler.LoadScenes(sceneGroup[index], progress);
            EnableLoadingCanvas(false);
        }

        private void EnableLoadingCanvas(bool enable = true)
        {
            isLoading = enable;
            loadingCanvas.gameObject.SetActive(enable);
            loadingCamera.gameObject.SetActive(enable);
        }
        
        
    }
}