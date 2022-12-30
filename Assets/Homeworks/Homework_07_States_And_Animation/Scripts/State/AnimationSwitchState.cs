using Homework_States.Animation;
using UnityEngine;

namespace Homework_States.State
{
    public class AnimationSwitchState : State
    {
        [SerializeField] private AnimationSystem animationSystem;
        [SerializeField] private AnimationStateType stateType;

        public override void Enter()
        {
            this.animationSystem.SwitchState(stateType);
        }
    }
}