using Sirenix.OdinInspector;
using UnityEngine;


namespace Homework_Mechanics.Engines
{
    public class MoveEngine : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField] private float speed = 3;

        public void Move(Vector3 direction)
        {
            direction *= speed * Time.deltaTime;
            positionEngine.Position += direction;
        }


    }
}

