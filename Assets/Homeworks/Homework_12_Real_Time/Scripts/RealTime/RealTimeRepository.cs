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

        public bool LoadData(out RealTimeData data)
        {
            if (PlayerPrefs.HasKey(PrefKey))
            {
                string json = PlayerPrefs.GetString(PrefKey);
                data = JsonUtility.FromJson<RealTimeData>(json);
                return true;
            }
            data = default;
            return false;
        }
    }
}