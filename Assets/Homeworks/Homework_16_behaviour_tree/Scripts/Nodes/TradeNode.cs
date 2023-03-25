using AI.Blackboards;
using AI.BTree;
using Entities;
using Homeworks.Homework_16_behaviour_tree.Tasks;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class TradeNode : UnityBehaviourNode,ITaskCallback
    {
        [SerializeField] private UnityBlackboard blackboard;
        [SerializeField] private TradeTask tradeTask;
        
        [Space, SerializeField, BlackboardKey] private string unitKey;
        [SerializeField, BlackboardKey] private string conveyorKey;
        [SerializeField, BlackboardKey] private string stoppingDistanceKey;
        
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }
            if (!this.blackboard.TryGetVariable(this.conveyorKey, out IEntity conveyor))
            {
                this.Return(false);
                return;
            }
            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                this.Return(false);
                return;
            }
            
            this.tradeTask.SetUnit(unit);
            this.tradeTask.SetStoppingDistance(stoppingDistance);
            this.tradeTask.SetConveyor(conveyor);
            
            this.tradeTask.Do(this);
        }

        public void OnComplete(Task task, bool saccess)
        {
            this.Return(saccess);
        }
    }
}