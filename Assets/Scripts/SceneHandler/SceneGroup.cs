using System;
using System.Collections.Generic;
using System.Linq;
using Enum;

namespace SceneHandler
{
    [Serializable]
    public class SceneGroup
    {
        public string GroupName = "New Scene Group";
        public List<SceneData> Scenes;

        public string FindSceneNameByType(SceneType sceneType)
        {
            return Scenes.FirstOrDefault(scene => scene.SceneType == sceneType).Name;
        }
    }
}