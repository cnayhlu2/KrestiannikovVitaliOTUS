using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_15_AI.Agents
{
    public abstract class Agent : MonoBehaviour
    {

        private bool isPlaying;
        public bool IsPlaying => this.isPlaying;

        [Button]
        public void Play()
        {
            if (this.isPlaying)
            {
                throw new Exception("Agent is playing");
                return;
            }

            this.isPlaying = true;
            this.OnPlay();
        }

        [Button]
        public void Stop()
        {
            if (!this.isPlaying)
            {
                throw new Exception("Agent is not playing");
                return;
            }

            this.isPlaying = false;
            this.OnStop();
        }

        protected abstract void OnPlay();

        protected abstract void OnStop();
    }
}