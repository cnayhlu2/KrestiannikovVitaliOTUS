using System;
using Homework_06_Conveyor;
using UnityEngine;

namespace Homework_States.State
{
    public abstract class StateMachine<T> : State where T : Enum
    {
        public event Action<T> OnStateChange;

        public T CurrentStateType => this.currentStateType;

        [SerializeField] private T currentStateType;

        [SerializeField] private bool enterOnEnable;
        [SerializeField] private bool exitOnDisable;

        [SerializeField] private StateDictionary<T> states = new();
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

        public void SwitchState(T type)
        {
            Debug.Log($"SwitchState");
            this.Exit();
            this.currentStateType = type;
            this.Enter();
            OnStateChange?.Invoke(type);
        }
    }

    [Serializable]
    public class StateDictionary<T> : UnitySerializedDictionary<T, State> where T : Enum
    {
    }
}