using Homework_States.Animation;
using UnityEngine;

namespace Homework_States.State
{
    public class AnimationSwitchState : State
    {
        private const string State = "State";

        [SerializeField] private Animator animator;
        [SerializeField] private AnimationStateType stateType;

        public override void Enter()
        {
            this.animator.SetInteger(State, (int) stateType);
        }
    }
}