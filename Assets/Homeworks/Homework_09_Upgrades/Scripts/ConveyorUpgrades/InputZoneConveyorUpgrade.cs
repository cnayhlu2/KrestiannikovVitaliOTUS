using Entities;
using Homework_06_Conveyor.Components;
using Homework_08_Interaction.Configs;

namespace Homework_08_Interaction.ConveyorUpgrades
{
    public class InputZoneConveyorUpgrade : ConveyorUpgrade
    {
        private InputZoneConveyorUpgradeConfig config;

        private IInputZoneComponent component;

        public InputZoneConveyorUpgrade(InputZoneConveyorUpgradeConfig config) : base(config)
        {
            this.config = config;
        }

        public override string GetStats()
        {
            string stat = "";

            if (Level > 0)
                stat += $"({config.AddSize * Level})";
            else
                stat += 0;
            if (!IsMaxLevel)
                stat += $" (+{config.AddSize})";
            return stat;
        }

        protected override void InitConveyor()
        {
            this.component = this.conveyor.Get<IInputZoneComponent>();
        }

        protected override void DoUpgrade()
        {
            this.component.AddStorageLimit(this.config.AddSize);
        }
    }
}