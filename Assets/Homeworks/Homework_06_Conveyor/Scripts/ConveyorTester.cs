using Entities;
using Homework_06_Conveyor.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorTester : MonoBehaviour
    {
        [SerializeField] private UnityEntity conveyor;

        [Button]
        void PutResource(ResourceType resourceType, int count)
        {
            ILoadZoneComponent loadZoneComponent = conveyor.Get<ILoadZoneComponent>();

            if (!loadZoneComponent.CanLoad(resourceType))
                return;

            int countUnloaded = loadZoneComponent.TryLoad(resourceType, count);
        }

        [Button]
        void TryGetSteel()
        {
            IInputZoneComponent inputZoneComponent = conveyor.Get<IInputZoneComponent>();
            if(inputZoneComponent.CanUnload())
                return;
            inputZoneComponent.UnloadAll();
        }
    }
}