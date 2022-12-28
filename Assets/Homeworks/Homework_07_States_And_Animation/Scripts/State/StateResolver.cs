using Elementary;
using Homework_States.Core;
using UnityEngine;

namespace Homework_States.State
{
    public sealed class StateResolver : MonoBehaviour
    {
        [SerializeField] private CharacterStateMachine stateMachine;
        [SerializeField] private MoveEngine moveEngine;
        [SerializeField] private BoolBehaviour attacker;


        private void OnEnable()
        {
            this.attacker.OnValueChanged += AttackerStateChange;
            this.moveEngine.OnStartMove += this.OnMoveStarted;
            this.moveEngine.OnStopMove += this.OnMoveStopped;
        }

        private void OnDisable()
        {
            this.attacker.OnValueChanged -= AttackerStateChange;
            this.moveEngine.OnStartMove -= this.OnMoveStarted;
            this.moveEngine.OnStopMove -= this.OnMoveStopped;
        }

        private void AttackerStateChange(bool isActive)
        {
            Debug.Log($"AttackerStateChange {isActive}");
            if (isActive && this.stateMachine.CurrentStateType != StateType.SHOOT)
            {
                this.stateMachine.SwitchState(StateType.SHOOT);
            }
            else if (!isActive && this.stateMachine.CurrentStateType == StateType.SHOOT)
            {
                this.stateMachine.SwitchState(StateType.IDLE);
            }
        }

        private void OnMoveStopped()
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