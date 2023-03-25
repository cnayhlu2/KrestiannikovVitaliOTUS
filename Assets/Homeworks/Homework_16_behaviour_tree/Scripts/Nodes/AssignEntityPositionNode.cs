using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class AssignEntityPositionNode : UnityBehaviourNode
    {
        [SerializeField] private UnityBlackboard blackboard;
        [SerializeField, BlackboardKey] private string entityKey;
        [SerializeField, BlackboardKey] private string movePositionKey;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.entityKey, out IEntity entity))
            {
                this.Return(false);
                return;
            }

            var positionComponent = entity.Get<IComponent_GetPosition>();
            
            if(this.blackboard.HasVariable(this.movePositionKey))
                this.blackboard.ChangeVariable(this.movePositionKey,positionComponent.Position);
            else
                this.blackboard.AddVariable(this.movePositionKey,positionComponent.Position);
            
            this.Return(true);
            
        }
    }
}