using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Homework_Mechanics.Engines
{
    public class TransformEngine : MonoBehaviour
    {
        public Action<Vector3> OnPositionChanged;

        [SerializeField] private Transform currentTransform;
        [SerializeField, ValidateInput("@transforms.Count>0", "Add any transforms")] 
        private List<Transform> transforms = new List<Transform>();
        
        private Vector3 position;

        public Vector3 Position
        {
            get => position;
            set
            {
                this.position = value;
                transforms.ForEach(transform => transform.position = this.position);
                OnPositionChanged?.Invoke(this.position);
            }
        }

        public Transform GetCurrentTransform => currentTransform;

        private void Awake()
        {
            this.position = currentTransform.position;
        }

    }
}


