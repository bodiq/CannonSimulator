using System;
using Eflatun.SceneReference;
using Enum;

namespace SceneHandler
{
    [Serializable]
    public struct SceneData
    {
        public SceneReference Reference;
        public string Name => Reference.Name;
        public SceneType SceneType;
    }
}