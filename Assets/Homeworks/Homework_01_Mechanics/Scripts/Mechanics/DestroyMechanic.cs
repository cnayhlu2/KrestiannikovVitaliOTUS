using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class DestroyMechanic : MonoBehaviour
    {
        [SerializeField, Required] private MonoBoolVariable state;
        [SerializeField, Required] private GameObject target;

        private void OnEnable()
        {
            state.OnValueChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            state.OnValueChanged -= OnValueChanged;
        }

        private void OnValueChanged(bool isDestoy)
        {
            if(isDestoy)
                GameObject.Destroy(target);
        }
    }
}


