using System.Collections.Generic;
using UnityEngine;

namespace Homework_11_Chests
{
    public class Chest
    {
        private readonly ChestConfig chestConfig;

        public Sprite Icon => this.chestConfig.GetIcon;
        public ChestType Type => this.chestConfig.ChestType;
        public List<RewardConfig> Rewards => this.chestConfig.Rewards;

        public Chest(ChestConfig chestConfig)
        {
            this.chestConfig = chestConfig;
        }
    }
}