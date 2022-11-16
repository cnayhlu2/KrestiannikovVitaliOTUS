using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class GravityMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField] private float gravitySpeed = 1f;

        private void FixedUpdate()
        {
            if (!positionEngine.IsOnGround)
            {
                positionEngine.Value -= new Vector3(0, gravitySpeed * Time.deltaTime, 0);
            }
        }


    }
}

