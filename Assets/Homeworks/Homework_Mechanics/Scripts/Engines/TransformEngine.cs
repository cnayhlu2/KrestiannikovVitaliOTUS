using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Homework_Mechanics.Engines
{
    public class TransformEngine : MonoBehaviour
    {
        public Action<Vector3> OnValueChanged;


        private const int groundHeight = 0;

        [SerializeField, ValidateInput("@transforms.Count>0", "Add any transforms")] private List<Transform> transforms = new List<Transform>();

        public Vector3 Value
        {
            get => value;
            set
            {
                this.value = value;
                if (this.value.y < groundHeight)
                    this.value.y = groundHeight;
                transforms.ForEach(transform => transform.position = this.value);
                OnValueChanged?.Invoke(this.value);
            }
        }

        public bool IsOnGround => this.value.y == groundHeight;
        public Transform GetCurrentTransform => currentTransform;

        [SerializeField] private Transform currentTransform;
        [SerializeField] private Vector3 value;

        private void Awake()
        {
            this.value = currentTransform.position;
        }

    }
}


