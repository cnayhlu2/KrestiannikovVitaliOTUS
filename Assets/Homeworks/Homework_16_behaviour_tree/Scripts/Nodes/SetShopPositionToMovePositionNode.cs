using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class SetShopPositionToMovePositionNode : UnityBehaviourNode
    {
        [SerializeField] private UnityBlackboard blackboard;
        [SerializeField] [BlackboardKey] private string moveToPositionKey;
        [SerializeField] [BlackboardKey] private string shopToPositionKey;


        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.shopToPositionKey, out Vector3 shopPosition))
            {
                this.Return(false);
                return;
            }
            
            if(this.blackboard.HasVariable(this.moveToPositionKey))
                this.blackboard.ChangeVariable(this.moveToPositionKey,shopPosition);
            else
                this.blackboard.AddVariable(this.moveToPositionKey,shopPosition);
            
            this.Return(true);
        }
    }
}