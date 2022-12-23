using System;
using System.Collections.Generic;

namespace Homeworks.Homework_05_Save_Load.Upgrades
{
    [Serializable]
    public class UpgradesData
    {
        public List<UpgradeData> upgrades = new();
    }

    [System.Serializable]
    public struct UpgradeData
    {
        public string Name;
        public int Level;
    }
}