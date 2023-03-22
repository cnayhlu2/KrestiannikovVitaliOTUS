using AI.Blackboards;
using AI.BTree;
using Entities;
using Homeworks.Homework_16_behaviour_tree.Tasks;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class MoveToPositionNode : BehaviourNode, ITaskCallback
    {
        [SerializeField] private MoveTask moveTask;

        [SerializeField] private UnityBlackboard blackboard;

        [SerializeField] [BlackboardKey] private string unitKey;
        [SerializeField] [BlackboardKey] private string moveToPositionKey;
        [SerializeField] [BlackboardKey] private string stoppingDistanceKey;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity entity))
            {
                this.Return(false);
                return;
            }
            if (!this.blackboard.TryGetVariable(this.unitKey, out Vector3 movePosition))
            {
                this.Return(false);
                return;
            }
            if (!this.blackboard.TryGetVariable(this.unitKey, out float stoppingDistance))
            {
                this.Return(false);
                return;
            }
            
            
            this.moveTask.SetEntity(entity);
            this.moveTask.SetMovePosition(movePosition);
            this.moveTask.SetStoppingDistance(stoppingDistance);
            this.moveTask.Do(this);
        }

        protected override void OnAbort()
        {
            this.moveTask.Cansel();
        }

        void ITaskCallback.OnComplete(Task task, bool saccess)
        {
            this.Return(saccess);
        }
    }
}