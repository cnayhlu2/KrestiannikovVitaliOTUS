using UnityEngine;
using UnityEngine.Events;

namespace Homework_States.Animation
{
    public class AnimationState_InvokeUnityEvent : State.State
    {
        [SerializeField] private AnimationSystem animationSystem;
        [SerializeField] private UnityEvent unityEvent;
        [SerializeField] private string eventKey;


        public override void Enter()
        {
            this.animationSystem.OnEventReceived += this.OnEvent;
        }

        public override void Exit()
        {
            this.animationSystem.OnEventReceived -= this.OnEvent;
        }

        private void OnEvent(string key)
        {
            if (this.eventKey == key)
                this.unityEvent.Invoke();
        }
    }
}