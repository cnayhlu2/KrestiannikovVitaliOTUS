using Homework_States.Core;
using UnityEngine;

namespace Homework_States.State
{
    public sealed class StateResolver : MonoBehaviour
    {
        [SerializeField] private CharacterStateMachine stateMachine;
        [SerializeField] private MoveEngine moveEngine;

        private void OnEnable()
        {
            this.moveEngine.OnStartMove += this.OnMoveStarted;
            this.moveEngine.OnStopMove += this.OnMoveStoped;
        }

        private void OnDisable()
        {
            this.moveEngine.OnStartMove -= this.OnMoveStarted;
            this.moveEngine.OnStopMove -= this.OnMoveStoped;
        }

        private void OnMoveStoped()
        {
            if (this.stateMachine.CurrentStateType == StateType.MOVE)
            {
                this.stateMachine.SwitchState(StateType.IDLE);
            }
        }

        private void OnMoveStarted()
        {
            if (this.stateMachine.CurrentStateType == StateType.IDLE)
            {
                this.stateMachine.SwitchState(StateType.MOVE);
            }
        }
    }
}