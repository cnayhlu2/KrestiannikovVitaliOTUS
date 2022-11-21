﻿using Entities;
using Homework_Components.Components;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Components
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField, Required] private UnityEntity target;
        [SerializeField, Required] private KeyboardInput keyboardInput;
        

        private IMoveComponent moveComponent;

        private void Awake()
        {
            moveComponent = target.Get<IMoveComponent>();
        }

        private void OnEnable()
        {
            keyboardInput.OnMove += Move;
        }

        private void OnDisable()
        {
            keyboardInput.OnMove -= Move;
        }

        private void Move(Vector3 direction)
        {
            moveComponent.Move(direction);
        }
    }
}