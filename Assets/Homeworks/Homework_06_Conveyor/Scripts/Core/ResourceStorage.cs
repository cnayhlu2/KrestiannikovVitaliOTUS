using System;
using System.Collections.Generic;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_06_Conveyor.Core
{
    public class ResourceStorage : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary resources = new();

        public LimitedInt GetStorage(ResourceType resourceType)
        {
            if (!resources.ContainsKey(resourceType))
                throw new Exception($"Do not have storage by type {resourceType}");
            return resources[resourceType];
        }
        
        public bool CanLoad(ResourceType resourceType)
        {
            if (!resources.ContainsKey(resourceType))
                return false;
            return !resources[resourceType].IsLimit;
        }

        [Button]
        public int TryLoad(ResourceType resourceType, int count)
        {
            if (!resources.ContainsKey(resourceType))
                return count;
            var resourceStorage = resources[resourceType];
            var space = resourceStorage.MaxValue - resourceStorage.Value;
            resourceStorage.Value += count;
            return (space >= count) ? 0 : count - space;
        }

        public bool CanUnload(ResourceType resourceType)
        {
            if (!resources.ContainsKey(resourceType))
                return false;
            return resources[resourceType].Value > 0;
        }

        public int UnloadAll(ResourceType resourceType)
        {
            if (!resources.ContainsKey(resourceType))
                return 0;
            var resourceStorage = resources[resourceType];
            var count = resourceStorage.Value;
            resourceStorage.Value = 0;
            return count;
        }

        public void Unload(ResourceType resourceType, int count)
        {
            if (!resources.ContainsKey(resourceType))
                return;
            resources[resourceType].Value -= count;
        }
    }

    [System.Serializable]
    public class SerializedDictionary : UnitySerializedDictionary<ResourceType, LimitedInt>
    {
    }
}