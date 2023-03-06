using System;
using GameSystem;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts.RealTime
{
    public class RealTimeSaver : MonoBehaviour, IGameConstructElement, IGameReadyElement, IGameFinishElement
    {
        private RealTimeManager manager;
        private RealTimeRepository repository = new();

        public void ConstructGame(IGameContext context)
        {
            this.manager = context.GetService<RealTimeManager>();
        }


        void IGameReadyElement.ReadyGame()
        {
            if (this.repository.LoadData(out RealTimeData data))
            {
                long lastTime = data.Seconds;
                this.manager.Begin(GetCurrentTime, GetCurrentTime - lastTime);
            }
            else
            {
                this.manager.Begin(GetCurrentTime);
            }
        }

        void IGameFinishElement.FinishGame()
        {
            RealTimeData data = new()
            {
                Seconds = GetCurrentTime,
            };
            this.repository.SaveTime(data);
        }

        private long GetCurrentTime
        {
            get
            {
                var dateNow = DateTime.Now.ToUniversalTime();
                var originTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                var timeSpan = dateNow - originTime;
                return (long) timeSpan.TotalSeconds;
            }
        }
    }
}