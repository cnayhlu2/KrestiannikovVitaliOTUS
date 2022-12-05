using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class GravityMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField, Required] private GroundChecker groundChecker;
        [SerializeField] private float force = 1f;

        private void FixedUpdate()
        {
            if (!groundChecker.IsOnGround)
                positionEngine.Position -= new Vector3(0, force * Time.deltaTime, 0);
        }
    }
}