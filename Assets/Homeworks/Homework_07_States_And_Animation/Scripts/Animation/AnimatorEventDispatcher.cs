using System;
using UnityEngine;

namespace Homework_States.Animation
{
    public sealed class AnimatorEventDispatcher : MonoBehaviour
    {
        public event Action<string> OnEventReceived;

        public void ReceiveEvent(string key)
        {
            Debug.Log($"key : {key}");
            this.OnEventReceived?.Invoke(key);
        }
    }
}