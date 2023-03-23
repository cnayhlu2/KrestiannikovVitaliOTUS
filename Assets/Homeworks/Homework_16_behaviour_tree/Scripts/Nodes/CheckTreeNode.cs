using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class CheckTreeNode : UnityBehaviourNode
    {
        [SerializeField] private UnityBlackboard blackboard;
        [SerializeField, BlackboardKey] private string resourceLocationKey;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.resourceLocationKey, out Transform resource))
            {
                this.Return(false);
                return;
            }
            
            this.Return(true);
        }
    }
}