using Elementary;
using Homework_06_Conveyor.Core;
using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorZoneVisualAdapter : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private ResourceStorage resourceStorage;
        [SerializeField] private ConveyorZoneVisual visual;

        private LimitedInt storage;

        private void OnEnable()
        {
            storage = this.resourceStorage.GetStorage(resourceType);
            storage.OnValueChanged += this.visual.Set;
            this.visual.Set(storage.Value);
        }

        private void OnDisable()
        {
            storage.OnValueChanged -= this.visual.Set;
        }
    }
}