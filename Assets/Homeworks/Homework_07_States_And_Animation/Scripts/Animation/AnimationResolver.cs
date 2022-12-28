using System;
using Homework_States.State;
using UnityEngine;

namespace Homework_States.Animation
{
    public sealed class AnimationResolver : MonoBehaviour
    {
        [SerializeField] private AnimationSystem animationSystem;
        [SerializeField] private AnimationStateMachine stateMachine;
        [SerializeField] private CharacterStateMachine characterStateMachine;

        private void Awake()
        {
            this.UpdateState(AnimationStateType.IDLE);
        }

        private void OnEnable()
        {
            this.characterStateMachine.OnStateChange += OnCharacterStateChange;
        }

        private void OnDisable()
        {
            this.characterStateMachine.OnStateChange -= OnCharacterStateChange;
        }

        private void OnCharacterStateChange(StateType stateType)
        {
            switch (stateType)
            {
                case StateType.IDLE:
                    UpdateState(AnimationStateType.IDLE);
                    break;
                case StateType.MOVE:
                    UpdateState(AnimationStateType.MOVE);
                    break;
                case StateType.SHOOT:
                    if(stateMachine.CurrentStateType==AnimationStateType.MOVE)
                        UpdateState(AnimationStateType.IDLE);
                    UpdateState(AnimationStateType.SHOOT);
                    break;
            }
        }


        private void UpdateState(AnimationStateType stateType)
        {
            this.animationSystem.SwitchState(stateType);
            this.stateMachine.SwitchState(stateType);
        }
    }
}