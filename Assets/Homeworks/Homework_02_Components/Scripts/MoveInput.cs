using GameElements;
using System;
using UnityEngine;

namespace Homework_Components
{
    public sealed class MoveInput : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        public Action<Vector3> OnMove;
        public Action OnJump;

        private void Awake()
        {
            this.enabled = false;
        }

        private void FixedUpdate()
        {
            this.HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Move(Vector3.back);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(Vector3.right);
            }
            
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }

        private void Move(Vector3 direction)
        {
            this.OnMove?.Invoke(direction);
        }

        private void Jump()
        {
            this.OnJump?.Invoke();
        }
        void IGameStartElement.StartGame(IGameContext context)
        {
            this.enabled = true;
        }

        void IGameFinishElement.FinishGame(IGameContext context)
        {
            this.enabled = false;
        }

    }
}


