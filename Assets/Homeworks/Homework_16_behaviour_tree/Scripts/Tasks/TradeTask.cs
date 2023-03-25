using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Homework_06_Conveyor.Components;
using Sirenix.OdinInspector;

namespace Homeworks.Homework_16_behaviour_tree.Tasks
{
    //заглушка
    public class TradeTask : Task
    {
        [ShowInInspector,ReadOnly] private IEntity unit;
        [ShowInInspector,ReadOnly] private IEntity conveyor;
        [ShowInInspector, ReadOnly] private float stoppingDistance;

        public void SetUnit(IEntity unit)
        {
            this.unit = unit;
        }
        
        public void SetConveyor(IEntity conveyor)
        {
            this.conveyor = conveyor;
        }

        public void SetStoppingDistance(float stoppingDistance)
        {
            this.stoppingDistance = stoppingDistance;
        }
        
        protected override void Do()
        {
            //check distance
            var conveyorPosition = this.conveyor.Get<IComponent_GetPosition>();
            var unitPosition = this.unit.Get<IComponent_GetPosition>();

            var distanceVector = conveyorPosition.Position - unitPosition.Position;
            var distance = distanceVector.magnitude;
            if (distance > this.stoppingDistance)
            {
                this.Complete(false);
                return;
            }
            
            //try put resource
            var resourceComponent = unit.Get<IComponent_ResourceSource>();
            var conveyorInputComponent = conveyor.Get<ILoadZoneComponent>();

            var allResource = resourceComponent.GetAllResources();

            for (int i = 0; i < allResource.Length; i++)
            {
                int count = conveyorInputComponent.TryLoad(allResource[i].type,allResource[i].amount);
                resourceComponent.ExtractResources(allResource[i].type,allResource[i].amount -count);
            }
            this.Complete(true);
        }

        protected override void OnCansel()
        {
        }
    }
}