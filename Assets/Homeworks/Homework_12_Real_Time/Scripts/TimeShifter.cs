using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts
{
    public sealed class TimeShifter : MonoBehaviour
    {
        private List<ITimeSynchronizer> synchronizers = new();


        [Button]
        public void PassedTime(float time)
        {
            foreach (var synchronizer in this.synchronizers)
            {
                synchronizer.TimePassed(time);
            }
        }

        public void AddSynchronizer(ITimeSynchronizer synchronizer)
        {
            this.synchronizers.Add(synchronizer);
        }

        public void RemoveSynchronizer(ITimeSynchronizer synchronizer)
        {
            this.synchronizers.Remove(synchronizer);
        }
    }
}