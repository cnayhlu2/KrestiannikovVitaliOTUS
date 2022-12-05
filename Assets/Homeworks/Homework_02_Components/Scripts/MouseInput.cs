using GameElements;
using Homework_Game_Context.GameContext;
using System;
using UnityEngine;

namespace Homework_Components
{
    public sealed class MouseInput : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        public Action<Vector3> OnMousePress;

        private void Awake()
        {
            this.enabled = false;
        }

        private void FixedUpdate()
        {
            this.HandleMouse();
        }

        private void HandleMouse()
        {
            if (Input.GetMouseButton(0))
            {
                Press(Input.mousePosition);
            }
        }

        private void Press(Vector3 position)
        {
            this.OnMousePress?.Invoke(position);
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


