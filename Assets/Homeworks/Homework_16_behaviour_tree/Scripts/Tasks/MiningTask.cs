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
        [ShowInInspector,ReadOnly] private IEntity unit;
        [ShowInInspector,ReadOnly] private IEntity tree;
        [ShowInInspector, ReadOnly] private float stoppingDistance;

        public void SetUnit(IEntity unit)
        {
            this.unit = unit;
        }

        public void SetTree(IEntity tree)
        {
            this.tree = tree;
        }

        public void SetStoppingDistance(float stoppingDistance)
        {
            this.stoppingDistance = stoppingDistance;
        }
        
        
        protected override void Do()
        {
            var unitPositionComponent = this.unit.Get<IComponent_GetPosition>();
            var treePositionComponent = this.tree.Get<IComponent_GetPosition>();
            
            var distanceVector = unitPositionComponent.Position - treePositionComponent.Position;
            var distance = distanceVector.magnitude;
            if (distance > this.stoppingDistance)
            {
                this.Complete(false);
                return;
            }


            var resource_component = this.unit.Get<IComponent_ResourceSource>();
            Debug.Log($"put resource");
            resource_component.PutResources(ResourceType.WOOD,1);
            
            var treeDestroyComponent = this.tree.Get<IComponent_Destoy>();
            treeDestroyComponent.Destroy();
            this.Complete(true);
        }

        protected override void OnCansel()
        {
        }
    }
}