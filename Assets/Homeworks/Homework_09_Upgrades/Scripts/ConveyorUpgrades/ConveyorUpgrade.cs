using System;
using Entities;
using Homework_08_Interaction.Components;
using Homework_08_Interaction.Configs;
using Sirenix.OdinInspector;

namespace Homework_08_Interaction.ConveyorUpgrades
{
    public abstract class ConveyorUpgrade
    {
        public event Action<int> OnUpgrade;
        protected IEntity conveyor;

        // protected string Id;
        [ShowInInspector, ReadOnly] public int Level => this.currentLevel;

        public bool IsMaxLevel => this.currentLevel >= this.config.MaxLevel;

        public int GetPrice => this.config.Price;
        public string GetId => this.conveyor.Get<IIDComponent>().GetId();


        private ConveyorUpgradeConfig config;
        private int currentLevel;

        // public void SetId(string conveyorId) => this.Id = conveyorId;

        public void SetupConveyor(IEntity conveyor)
        {
            this.conveyor = conveyor;
            InitConveyor();
            SetUpgradesByLevel();
        }

        public void Upgrade()
        {
            if (IsMaxLevel)
            {
                throw new Exception("Level is max");
            }

            this.currentLevel = this.Level + 1;
            this.DoUpgrade();
            this.OnUpgrade?.Invoke(currentLevel);
        }

        public void SetLevel(int newLevel)
        {
            this.currentLevel = newLevel;
        }

        protected ConveyorUpgrade(ConveyorUpgradeConfig config)
        {
            this.config = config;
        }

        protected abstract void DoUpgrade();

        protected abstract void InitConveyor();

        private void SetUpgradesByLevel()
        {
            for (int i = 0; i < Level; i++)
                DoUpgrade();
        }
    }
}