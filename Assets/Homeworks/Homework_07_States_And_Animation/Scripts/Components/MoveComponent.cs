using Homework_Components.Components;
using Homework_States.Core;
using UnityEngine;

namespace Homeworks.Homework_07_States_And_Animation.Scripts.Components
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