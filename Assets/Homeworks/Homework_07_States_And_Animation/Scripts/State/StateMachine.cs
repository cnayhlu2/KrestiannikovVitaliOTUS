using System;
using Homework_06_Conveyor;
using UnityEngine;

namespace Homework_States.State
{
    public sealed class StateMachine : State
    {
        public StateType CurrentStateType => this.currentStateType;

        [SerializeField] private StateType currentStateType;

        [SerializeField] private bool enterOnEnable;
        [SerializeField] private bool exitOnDisable;

        [SerializeField] private StateDictionary states = new();
        private State currentState;

        private void OnEnable()
        {
            if (this.enterOnEnable)
            {
                this.Enter();
            }
        }

        private void OnDisable()
        {
            if (this.exitOnDisable)
            {
                this.Exit();
            }
        }

        public override void Enter()
        {
            if (this.currentState == null)
            {
                this.currentState = this.states[this.currentStateType];
                this.currentState.Enter();
            }
        }

        public override void Exit()
        {
            if (this.currentState != null)
            {
                this.currentState.Exit();
                this.currentState = null;
            }
        }

        public void SwitchState(StateType type)
        {
            Debug.Log("SwitchState");
            this.Exit();
            this.currentStateType = type;
            this.Enter();
        }
    }

    [Serializable]
    public class StateDictionary : UnitySerializedDictionary<StateType, State>
    {
    }
}