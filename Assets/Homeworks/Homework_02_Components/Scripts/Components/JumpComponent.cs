using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Components.Components
{
    public sealed class JumpComponent : MonoBehaviour, IJumpComponent
    {
        [SerializeField, Required] private EventReceiver jumpReceiver;

        public void Jump()
        {
            this.jumpReceiver.Call();
        }
    }
}