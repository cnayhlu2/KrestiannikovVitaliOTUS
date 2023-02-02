using Homework_06_Conveyor.Core;
using UnityEngine;

namespace Homework_06_Conveyor.Components
{
    public class LoadZoneComponent : MonoBehaviour, ILoadZoneComponent
    {
        [SerializeField] private ResourceStorage resourceStorage;

        bool ILoadZoneComponent.CanLoad(ResourceType resourceType)
        {
            return resourceStorage.CanLoad(resourceType);
        }

        int ILoadZoneComponent.TryLoad(ResourceType resourceType, int count)
        {
            return resourceStorage.TryLoad(resourceType, count);
        }

        void ILoadZoneComponent.AddStorageLimit(int size)
        {
            resourceStorage.AddStorageLimit(size);
        }
    }
}