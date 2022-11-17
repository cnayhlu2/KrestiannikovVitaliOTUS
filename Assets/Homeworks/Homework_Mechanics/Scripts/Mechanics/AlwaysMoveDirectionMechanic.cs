using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class AlwaysMoveDirectionMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField, Required] private GroundChecker groundChecker;
        [SerializeField] private Vector3 direction;

        private void FixedUpdate()
        {
            if (!groundChecker.IsOnGround)
                positionEngine.Position += (direction * Time.deltaTime);
        }


    }
}

