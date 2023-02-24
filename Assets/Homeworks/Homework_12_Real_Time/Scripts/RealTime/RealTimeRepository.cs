using System;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts.RealTime
{
    public class RealTimeRepository
    {
        private const string PrefKey = nameof(PrefKey);

        public void SaveTime(RealTimeData data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(PrefKey, json);
        }

        public void LoadData(out RealTimeData data)
        {
            if (PlayerPrefs.HasKey(PrefKey))
            {
                string json = PlayerPrefs.GetString(PrefKey);
                data = JsonUtility.FromJson<RealTimeData>(json);
            }
            else
            {
                data = new RealTimeData();
                data.Seconds = DateTime.Now.Second;
            }
        }
    }
}