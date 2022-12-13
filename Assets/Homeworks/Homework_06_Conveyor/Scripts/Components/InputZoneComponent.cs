using Elementary;
using UnityEngine;

namespace Homework_06_Conveyor.Components
{
    public class InputZoneComponent : MonoBehaviour, IInputZoneComponent
    {
        [SerializeField] private LimitedIntBehavior inputStorage;

        bool IInputZoneComponent.CanUnload()
        {
            return inputStorage.Value == 0;
        }

        int IInputZoneComponent.UnloadAll()
        {
            int count = inputStorage.Value;
            inputStorage.Value = 0;
            return count;
        }
    }
}