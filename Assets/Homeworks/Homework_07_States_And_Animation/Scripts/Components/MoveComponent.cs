using Homework_Components.Components;
using Homework_States.Core;
using UnityEngine;

namespace Homework_States.Components
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private MoveEngine moveEngine;

        public void Move(Vector3 direction)
        {
            moveEngine.Move(direction);
        }
    }
}