using Entities;
using Homework_08_Interaction.Components;
using Homework_08_Interaction.Configs;

namespace Homework_08_Interaction.ConveyorUpgrades
{
    public class TimeConveyorUpgrade : ConveyorUpgrade
    {
        private TimeConveyorUpgradeConfig config;
        // private IConveyorService service;
        private IConveyorTimeComponent timeComponent;

        public TimeConveyorUpgrade(TimeConveyorUpgradeConfig config) : base(config)
        {
            this.config = config;
        }
        
        public override string GetStats()
        {
            string stat = "";

            if (Level > 0)
                stat += $"-{config.ReduceTime * Level}";
            else
                stat += 0;
            if (!IsMaxLevel)
                stat += $" (-{config.ReduceTime})";
            return stat;
        }

        protected override void InitConveyor()
        {
            this.timeComponent = this.conveyor.Get<IConveyorTimeComponent>();

        }

        protected override void DoUpgrade()
        {
            this.timeComponent.ReduceTime(config.ReduceTime);
        }
    }
}