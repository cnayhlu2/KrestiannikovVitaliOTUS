using Elementary;
using Homework_States.Core;
using UnityEngine;

namespace Homework_States.State
{
    public class CharacterStateMachine : StateMachine<StateType>
    {
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
            if (isActive && this.CurrentStateType != StateType.SHOOT)
            {
                this.SwitchState(StateType.SHOOT);
            }
            else if (!isActive && this.CurrentStateType == StateType.SHOOT)
            {
                this.SwitchState(StateType.IDLE);
            }
        }

        private void OnMoveStopped()
        {
            if (this.CurrentStateType == StateType.MOVE)
            {
                this.SwitchState(StateType.IDLE);
            }
        }

        private void OnMoveStarted()
        {
            if (this.CurrentStateType == StateType.IDLE)
            {
                this.SwitchState(StateType.MOVE);
            }
        }
    }
}