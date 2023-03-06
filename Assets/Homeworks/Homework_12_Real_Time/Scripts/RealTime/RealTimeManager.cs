using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts.RealTime
{
    public class RealTimeManager : MonoBehaviour
    {
        public event Action<long> OnStarted;
        public event Action OnEnded;

        private bool isActive = false;


        [ShowInInspector] private long realTimeSeconds;
        private long sleepSeconds;
        private float secondAcc;

        private void Update()
        {
            if (this.isActive)
            {
                secondAcc += Time.deltaTime;
                if (secondAcc < 1)
                    return;
                int seconds = (int) this.secondAcc;
                realTimeSeconds += seconds;
                this.secondAcc -= seconds;
            }
        }

        public void Begin(long realTimeSeconds, long sleepSeconds = 0)
        {
            this.isActive = true;
            this.realTimeSeconds = realTimeSeconds;
            this.sleepSeconds = sleepSeconds;
            this.OnStarted?.Invoke(this.sleepSeconds);
        }

        public void End()
        {
            this.isActive = false;
            this.OnEnded?.Invoke();
        }
    }
}