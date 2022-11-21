using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Components.Components
{
    public class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField, Required] private EventReceiver_Int takeDamageReceiver;

        public void TakeDamage(int damage)
        {
            this.takeDamageReceiver.Call(damage);
        }
    }
}