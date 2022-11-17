using Elementary;
using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class DestroyOnGroundMechanic : MonoBehaviour
    {
        [SerializeField, Required] private GroundChecker groundChecker;
        [SerializeField, Required] private BoolBehaviour isNeedToDestroyState;

        private void FixedUpdate()
        {
            if (!isNeedToDestroyState.Value && groundChecker.IsOnGround)
                isNeedToDestroyState.AssignTrue();
        }
    }
}