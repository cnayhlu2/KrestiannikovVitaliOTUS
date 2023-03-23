using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class AssignResourcePositionNode : UnityBehaviourNode
    {
        [SerializeField] private UnityBlackboard blackboard;
        [SerializeField, BlackboardKey] private string resourceLocationKey;
        [SerializeField, BlackboardKey] private string movePositionKey;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.resourceLocationKey, out Transform resource))
            {
                this.Return(false);
                return;
            }
            
            if(this.blackboard.HasVariable(this.movePositionKey))
                this.blackboard.ChangeVariable(this.movePositionKey,resource.position);
            else
                this.blackboard.AddVariable(this.movePositionKey,resource.position);
            
            this.Return(true);
            
        }
    }
}