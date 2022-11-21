using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class DeathMechanic : MonoBehaviour
    {
        [SerializeField, Required] private LimitedIntBehavior hitPoints;
        [SerializeField, Required] private EventReceiver deathReceiver;

        private void OnEnable()
        {
            hitPoints.OnValueChanged += OnHitPointChanged;
        }
        private void OnDisable()
        {
            hitPoints.OnValueChanged -= OnHitPointChanged;
        }

        private void OnHitPointChanged(int health)
        {
            if (health <= 0)
                deathReceiver?.Call();
        }
    }
}

