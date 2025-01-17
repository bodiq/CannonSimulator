using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enum;
using UnityEngine.SceneManagement;

namespace SceneHandler
{
    public class SceneGroupHandler
    {
        public SceneGroupEvents SceneGroupEvents;

        private SceneGroup ActiveSceneGroup;

        public SceneGroupHandler()
        {
            SceneGroupEvents = new SceneGroupEvents();
        }

        public async Task LoadScenes(SceneGroup group, IProgress<float> progress, bool reloadDupScenes = false)
        {
            ActiveSceneGroup = group;

            var loadedScenes = new List<string>();

            await UnloadScenes();

            var sceneCount = SceneManager.sceneCount;

            for (var i = 0; i < sceneCount; i++)
            {
                loadedScenes.Add(SceneManager.GetSceneAt(i).name);
            }
            
            var totalScenesToLoad = ActiveSceneGroup.Scenes.Count;
            var operationGroup = new AsyncOperationGroup(totalScenesToLoad);

            for (var i = 0; i < totalScenesToLoad; i++)
            {
                var sceneData = group.Scenes[i];
                if(reloadDupScenes == false && loadedScenes.Contains(sceneData.Name)) continue;
                
                var operation = SceneManager.LoadSceneAsync(sceneData.Reference.Path, LoadSceneMode.Additive);
                
                operationGroup.Operations.Add(operation);
                
                SceneGroupEvents.OnSceneLoaded.Invoke(sceneData.Name);
            }

            while (!operationGroup.IsDone)
            {
                progress?.Report(operationGroup.Progress);
                await Task.Delay(100);
            }

            var activeScene = SceneManager.GetSceneByName(ActiveSceneGroup.FindSceneNameByType(SceneType.ActiveScene));

            if (activeScene.IsValid())
            {
                SceneManager.SetActiveScene(activeScene);
            }
            
            SceneGroupEvents.OnSceneGroupLoaded.Invoke();
        }

        public async Task UnloadScenes()
        {
            var scenes = new List<string>();
            var activeScene = SceneManager.GetActiveScene().name;
            
            var sceneCount = SceneManager.sceneCount;

            for (var i = 0; i < sceneCount; i++)
            {
                var sceneAt = SceneManager.GetSceneAt(i);
                if(!sceneAt.isLoaded) continue;
                
                var sceneName = sceneAt.name;
                if(sceneName.Equals(activeScene) || sceneName == "Bootstrapper") continue;
                scenes.Add(sceneName);
            }
            
            var operationGroup = new AsyncOperationGroup(scenes.Count);

            foreach (var scene in scenes)
            {
                var operation = SceneManager.UnloadSceneAsync(scene);
                if(operation == null) continue;
                
                operationGroup.Operations.Add(operation);
                
                SceneGroupEvents.OnSceneUnloaded.Invoke(scene);
            }

            while (!operationGroup.IsDone)
            {
                await Task.Delay(100);
            }
        }
    }
}