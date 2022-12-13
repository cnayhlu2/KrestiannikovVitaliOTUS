using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Engines
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine transformEngine;
        [SerializeField] private float distanceToGround = 0.01f;

        public bool IsOnGround => Physics.Raycast(transformEngine.Position, Vector3.down, distanceToGround);
        public float GetGroundHeight => distanceToGround;
    }
}