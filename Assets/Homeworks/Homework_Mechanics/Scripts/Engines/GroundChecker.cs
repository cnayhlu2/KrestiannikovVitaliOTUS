using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Engines
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine transformEngine;
        [SerializeField] private float groundHeight = 0f;

        public bool IsOnGround => transformEngine.Position.y <= groundHeight;
        public float GetGroundHeight => groundHeight;
    }
}