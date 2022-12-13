using Elementary;
using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorZoneVisualAdapter : MonoBehaviour
    {

        [SerializeField] private LimitedIntBehavior storage;
        [SerializeField] private ConveyorZoneVisual visual;

        private void OnEnable()
        {
            this.visual.Set(storage.Value);
            this.storage.OnValueChanged += this.visual.Set;
        }

        private void OnDisable()
        {
            this.storage.OnValueChanged -= this.visual.Set;
        }
    }
}