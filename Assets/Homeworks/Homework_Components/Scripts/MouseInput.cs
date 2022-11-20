using System;
using UnityEngine;

namespace Homework_Components
{
    public class MouseInput : MonoBehaviour
    {
        public Action<Vector3> OnMousePress;

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

    }
}


