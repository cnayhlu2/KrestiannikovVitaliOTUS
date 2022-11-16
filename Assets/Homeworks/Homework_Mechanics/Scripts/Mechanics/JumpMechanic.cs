using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class JumpMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField] private int jumpHeight = 5;

        [Button]
        public void Jump()
        {
            if (positionEngine.IsOnGround)
            {
                positionEngine.Value += new Vector3(0, jumpHeight, 0);
            }
        }
    }
}

