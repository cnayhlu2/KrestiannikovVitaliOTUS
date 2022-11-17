using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class MoveForwardMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField] private float speed = 1f;

        private void FixedUpdate()
        {
            positionEngine.Position += positionEngine.GetCurrentTransform.forward * speed * Time.deltaTime;
        }
    }
}