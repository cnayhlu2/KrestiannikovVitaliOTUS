using Entities;
using Homework_Components.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Components
{
    public sealed class JumpController : MonoBehaviour
    {
        [SerializeField, Required] private UnityEntity target;
        [SerializeField, Required] private MoveInput keyboardInput;

        private IJumpComponent jumpComponent;

        private void Awake()
        {
            jumpComponent = target.Get<IJumpComponent>();
        }

        private void OnEnable()
        {
            keyboardInput.OnJump += Jump;
        }

        private void OnDisable()
        {
            keyboardInput.OnJump -= Jump;
        }

        private void Jump()
        {
            jumpComponent.Jump();
        }
    }
}