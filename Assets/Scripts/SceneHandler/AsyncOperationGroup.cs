using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SceneHandler
{
    public readonly struct AsyncOperationGroup
    {
        public readonly List<AsyncOperation> Operations;
        
        public float Progress => Operations.Count == 0 ? 0 : Operations.Average(operation => operation.progress);
        public bool IsDone => Operations.All(operation => operation.isDone);

        public AsyncOperationGroup(int capacity)
        {
            Operations = new List<AsyncOperation>(capacity);
        }
    }
}