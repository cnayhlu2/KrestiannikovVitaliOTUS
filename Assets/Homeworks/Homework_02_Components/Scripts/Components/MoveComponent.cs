using Homework_Mechanics.Engines;
using UnityEngine;

namespace Homework_Components.Components
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