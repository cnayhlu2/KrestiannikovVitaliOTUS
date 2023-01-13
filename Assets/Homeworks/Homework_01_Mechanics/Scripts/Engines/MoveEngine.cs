using System;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Homework_Mechanics.Engines
{
    public class MoveEngine : MonoBehaviour
    {
        public event Action OnStartMove;
        public event Action OnStopMove;

        [SerializeField, Required] private TransformEngine positionEngine;
        [SerializeField] private float speed = 3;

        private Vector3 direction;
        private bool needToMove;
        private bool finishMove = true;

        private void FixedUpdate()
        {
            if (!needToMove) return;

            if (this.finishMove)
            {
                this.needToMove = false;
                this.StopMove();
            }

            this.direction *= speed * Time.deltaTime;
            this.positionEngine.Position += direction;
            this.finishMove = true;
        }


        public void Move(Vector3 direction)
        {
            this.direction = direction;

            if (!needToMove)
            {
                needToMove = true;
                this.StartMove();
            }

            finishMove = false;
        }

        private void StartMove()
        {
            Debug.Log("Start move");
            OnStartMove?.Invoke();
        }

        private void StopMove()
        {
            Debug.Log("Stop move");
            OnStartMove?.Invoke();
        }
    }
}