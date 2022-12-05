using Elementary;
using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class JumpMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField, Required] private EventReceiver receiver;
        [SerializeField, Required] private GroundChecker groundChecker;
        [SerializeField] private int jumpHeight = 5;

        private void OnEnable()
        {
            receiver.OnEvent += Jump;
        }

        private void OnDisable()
        {
            receiver.OnEvent -= Jump;
        }

        private void Jump()
        {
            if (groundChecker.IsOnGround)
                positionEngine.Position += new Vector3(0, jumpHeight, 0);
        }
    }
}

