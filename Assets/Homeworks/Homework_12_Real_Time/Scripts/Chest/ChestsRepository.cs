using System.Collections.Generic;
using Homework_11_Chests;
using UnityEngine;

namespace Homeworks.Homework_12_Real_Time.Scripts.Chest
{
    public class ChestsRepository
    {
        private const string ChestsKey = nameof(ChestsKey);

        public void Save(ChestsData data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(ChestsKey, json);
            Debug.Log($"save data: {json}");
        }

        public void LoadChestsData(out ChestsData data)
        {
            if (PlayerPrefs.HasKey(ChestsKey))
            {
                string json = PlayerPrefs.GetString(ChestsKey);
                data = JsonUtility.FromJson<ChestsData>(json);
                Debug.Log($"Load chests data {json}");
            }
            else
            {
                data = GetDefault();
                Debug.Log($"Load default data {JsonUtility.ToJson(data)}");
            }
        }

        private ChestsData GetDefault()
        {
            ChestsData data = new()
            {
                chests = new List<ChestData>()
                {
                    new() {Type = ChestType.WOOD, RemainingSeconds = 0f},
                    new() {Type = ChestType.STEEl, RemainingSeconds = 0f},
                    new() {Type = ChestType.GOLD, RemainingSeconds = 0f},
                }
            };
            return data;
        }
    }
}