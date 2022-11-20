using Sirenix.OdinInspector;
using UnityEngine;


namespace Homework_Mechanics.Engines
{
    public class MoveEngine : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField] private float distance = .5f;

        public void AddPosition(Vector3 addPosition)
        {
            positionEngine.Position += addPosition;
        }


    }
}

