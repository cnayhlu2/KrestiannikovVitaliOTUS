using Homework_06_Conveyor.Core;
using UnityEngine;

namespace Homework_06_Conveyor.Components
{
    public class InputZoneComponent : MonoBehaviour, IInputZoneComponent
    {
        [SerializeField] private ResourceStorage resourceStorage;

        bool IInputZoneComponent.CanUnload(ResourceType resourceType)
        {
            return resourceStorage.CanUnload(resourceType);
        }

        int IInputZoneComponent.UnloadAll(ResourceType resourceType)
        {
            return resourceStorage.UnloadAll(resourceType);
        }
    }
}