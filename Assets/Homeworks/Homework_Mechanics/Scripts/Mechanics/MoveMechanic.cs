using Homework_Mechanics.Engines;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Homework_Mechanics.Mechanics
{
    public class MoveMechanic : MonoBehaviour
    {
        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField] private float distance = .5f;

        [ButtonGroup("Move")]
        public void MoveToLeft()
        {
            AddPosition(new Vector3(0, 0, -distance));
        }
        [ButtonGroup("Move")]
        public void MoveToRight()
        {
            AddPosition(new Vector3(0, 0, distance));
        }

        [ButtonGroup("Move")]
        public void MoveToUp()
        {
            AddPosition(new Vector3(-distance, 0, 0));
        }
        [ButtonGroup("Move")]
        public void MoveToDown()
        {
            AddPosition(new Vector3(distance, 0, 0));
        }


        private void AddPosition(Vector3 addPosition)
        {
            positionEngine.Value += addPosition;
        }


    }
}

