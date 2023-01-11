using System;
using Homework_States.State;
using UnityEngine;

namespace Homework_States.Animation
{
    public class AnimationStateResolver : MonoBehaviour
    {
        public event Action<string> OnEventReceived
        {
            add => this.eventDispatcher.OnEventReceived += value;
            remove => this.eventDispatcher.OnEventReceived -= value;
        }

        [SerializeField] private AnimationStateMachine stateMachine;
        [SerializeField] private AnimatorEventDispatcher eventDispatcher;
        [SerializeField] private CharacterStateMachine characterStateMachine;

        private void OnEnable()
        {
            this.characterStateMachine.OnStateChange += OnCharacterSwitchState;
        }

        private void OnDisable()
        {
            this.characterStateMachine.OnStateChange -= OnCharacterSwitchState;
        }

        private void OnCharacterSwitchState(StateType state)
        {
            switch (state)
            {
                case StateType.IDLE:
                    this.stateMachine.SwitchState(AnimationStateType.IDLE);
                    break;
                case StateType.MOVE:
                    this.stateMachine.SwitchState(AnimationStateType.MOVE);
                    break;
                case StateType.SHOOT:
                    this.stateMachine.SwitchState(AnimationStateType.SHOOT);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}