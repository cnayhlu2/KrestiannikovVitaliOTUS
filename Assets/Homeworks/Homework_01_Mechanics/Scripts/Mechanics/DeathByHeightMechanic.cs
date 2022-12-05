using Elementary;
using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class DeathByHeightMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine target;
        [SerializeField, Required] private EventReceiver deathReceiver;
        [SerializeField] private float deathHeight = -.5f; 

        private void OnEnable()
        {
            target.OnPositionChanged += OnPositionChanged;
        }
        private void OnDisable()
        {
            target.OnPositionChanged -= OnPositionChanged;
        }

        private void OnPositionChanged(Vector3 position)
        {
            if (position.y < deathHeight)
            {
                deathReceiver?.Call();
            }
        }

    }
}