using GameSystem;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts.RealTime
{
    public class RealtimeSynchronizer : MonoBehaviour, IGameConstructElement, IGameFinishElement, IGameInitElement
    {
        private RealTimeManager manager;
        private TimeShifter timeShifter;

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            this.manager = context.GetService<RealTimeManager>();
            this.timeShifter = context.GetService<TimeShifter>();
        }

        void IGameInitElement.InitGame()
        {
            this.manager.OnStarted += PassedTime;
        }

        void IGameFinishElement.FinishGame()
        {
            this.manager.OnStarted -= PassedTime;
        }


        private void PassedTime(long time)
        {
            this.timeShifter.PassedTime(time);
        }
    }
}