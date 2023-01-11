using UnityEngine;
using UnityEngine.Events;

namespace Homework_States.Animation
{
    public class AnimationState_InvokeUnityEvent : State.State
    {
        [SerializeField] private AnimationStateResolver animationStateResolver;
        [SerializeField] private UnityEvent unityEvent;
        [SerializeField] private string eventKey;


        public override void Enter()
        {
            this.animationStateResolver.OnEventReceived += this.OnEvent;
        }

        public override void Exit()
        {
            this.animationStateResolver.OnEventReceived -= this.OnEvent;
        }

        private void OnEvent(string key)
        {
            if (this.eventKey == key)
                this.unityEvent.Invoke();
        }
    }
}