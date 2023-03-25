using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Tasks
{
    //заглушка
    public class MiningTask : Task
    {
        [ShowInInspector, ReadOnly] private IEntity unit;
        [ShowInInspector, ReadOnly] private IEntity resource;
        [ShowInInspector, ReadOnly] private float stoppingDistance;

        public void SetUnit(IEntity unit)
        {
            this.unit = unit;
        }

        public void SetTree(IEntity resource)
        {
            this.resource = resource;
        }

        public void SetStoppingDistance(float stoppingDistance)
        {
            this.stoppingDistance = stoppingDistance;
        }


        protected override void Do()
        {
            var unitPositionComponent = this.unit.Get<IComponent_GetPosition>();
            var treePositionComponent = this.resource.Get<IComponent_GetPosition>();

            var distanceVector = unitPositionComponent.Position - treePositionComponent.Position;
            var distance = distanceVector.magnitude;
            if (distance > this.stoppingDistance)
            {
                this.Complete(false);
                return;
            }

            var unitResource_component = this.unit.Get<IComponent_ResourceSource>();
            Debug.Log($"put resource");

            var resourceType_component = this.resource.Get<IComponent_GetResourceType>();
            var resourceCount_component = this.resource.Get<IComponent_GetResourceCount>();

            unitResource_component.PutResources(resourceType_component.Type, resourceCount_component.Count);

            var treeDestroyComponent = this.resource.Get<IComponent_Destoy>();
            treeDestroyComponent.Destroy();
            this.Complete(true);
        }

        protected override void OnCansel()
        {
        }
    }
}