using System;
using Homework_11_Chests;

namespace Homeworks.Homework_12_Real_Time.Scripts.Chest
{
    [Serializable]
    public struct ChestData
    {
        public ChestType Type;
        public float RemainingSeconds;
    }
}