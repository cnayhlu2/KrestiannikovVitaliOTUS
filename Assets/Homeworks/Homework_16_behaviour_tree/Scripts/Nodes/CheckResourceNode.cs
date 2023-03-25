using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class CheckResourceNode : UnityBehaviourNode
    {
        [SerializeField] private UnityBlackboard blackboard;
        [SerializeField, BlackboardKey] private string resourceCountKey;
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.resourceCountKey, out int countResource) || countResource==0)
            {
                this.Return(false);
                return;
            }
            
            this.Return(countResource>0);
        }
    }
}