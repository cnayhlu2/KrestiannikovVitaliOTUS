using System;
using UnityEngine;

namespace Homework_States.Core
{
    public sealed class MoveEngine : MonoBehaviour
    {
        public event Action OnStartMove;
        public event Action OnStopMove;

        private Vector3 direction;
        private bool needToMove;
        private bool finishMove = true;

        public Vector3 Direction => direction;

        private void FixedUpdate()
        {
            if (!needToMove) return;

            if (this.finishMove)
            {
                this.needToMove = false;
                this.StopMove();
            }

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
            Debug.Log("StartMove");
            OnStartMove?.Invoke();
        }

        private void StopMove()
        {
            Debug.Log("StopMove");
            OnStopMove?.Invoke();
        }
    }
}