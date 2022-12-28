using System;
using UnityEngine;

namespace Homework_States.Animation
{
    public class AnimationSystem : MonoBehaviour
    {
        private const string State = "State";

        public event Action<string> OnEventReceived
        {
            add => this.eventDispatcher.OnEventReceived += value;
            remove => this.eventDispatcher.OnEventReceived -= value;
        }

        [SerializeField] private Animator animator;
        [SerializeField] private AnimatorEventDispatcher eventDispatcher;
        [SerializeField] private AnimationStateMachine stateMachine;

        public void SwitchState(AnimationStateType stateType)
        {
            this.animator.SetInteger(State, (int) stateType);
            this.stateMachine.SwitchState(stateType);
        }
    }
}