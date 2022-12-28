using System;
using UnityEngine;

namespace Homework_States.Animation
{
    public sealed class AnimationResolver : MonoBehaviour
    {
        [SerializeField] private AnimationSystem animationSystem;
        [SerializeField] private AnimationStateMachine stateMachine;

        
        private void Awake()
        {
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void UpdateState(AnimationStateType stateType)
        {
            this.animationSystem.SwitchState(stateType);
            this.stateMachine.SwitchState(stateType);
        }
    }
}