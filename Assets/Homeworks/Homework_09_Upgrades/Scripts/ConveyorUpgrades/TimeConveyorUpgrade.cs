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

        public override void SetupConveyor(IEntity conveyor)
        {
            base.SetupConveyor(conveyor);
            this.timeComponent = this.conveyor.Get<IConveyorTimeComponent>();
        }

        protected override void DoUpgrade()
        {
            this.timeComponent.ReduceTime(config.ReduceTime);
        }

        // public void ConstructGame(IGameContext context)
        // {
        //     this.service = context.GetService<IConveyorService>();
        // }
        //
        // public void InitGame()
        // {
        //     this.timeComponent = service.GetConveyorById(Id).Get<IConveyorTimeComponent>();
        // }
    }
}