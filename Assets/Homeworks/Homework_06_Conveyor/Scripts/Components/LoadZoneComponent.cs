using System.Collections.Generic;
using Elementary;
using UnityEngine;

namespace Homework_06_Conveyor.Components
{
    public class LoadZoneComponent : MonoBehaviour, ILoadZoneComponent
    {
        [SerializeField] private List<ResourceStorageHolder> resourceStorages;
        private ILoadZoneComponent loadZoneComponentImplementation;

        bool ILoadZoneComponent.CanLoad(ResourceType resourceType)
        {
            foreach (var resourceStorage in resourceStorages)
            {
                if (resourceStorage.type == resourceType)
                    return !resourceStorage.storage.IsLimit;
            }

            return false;
        }

        int ILoadZoneComponent.TryLoad(ResourceType resourceType, int count)
        {
            foreach (var resourceStorage in resourceStorages)
            {
                if (resourceStorage.type == resourceType)
                {
                    int space = resourceStorage.storage.MaxValue - resourceStorage.storage.Value;
                    resourceStorage.storage.Value += count;
                    return (space >= count) ? 0 : count - space;
                }
            }
            return count;
        }
    }

    [System.Serializable]
    public class ResourceStorageHolder
    {
        public LimitedIntBehavior storage;
        public ResourceType type;
    }
}