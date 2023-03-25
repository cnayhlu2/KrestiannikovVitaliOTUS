using AI.Blackboards;
using AI.BTree;
using Entities;
using Homeworks.Homework_16_behaviour_tree.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class MiningNode : UnityBehaviourNode, ITaskCallback
    {
        [FormerlySerializedAs("killResourceTask")] [SerializeField] private MiningTask miningTask;

        [SerializeField] private UnityBlackboard blackboard;
        
        [SerializeField] [BlackboardKey] private string unitKey;
        [SerializeField, BlackboardKey] private string resourceLocationKey;
        [SerializeField] [BlackboardKey] private string stoppingDistanceKey;
        
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.resourceLocationKey, out IEntity resource))
            {
                this.Return(false);
                return;
            }
            
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }
            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                this.Return(false);
                return;
            }

            this.miningTask.SetTree(resource);
            this.miningTask.SetUnit(unit);
            this.miningTask.SetStoppingDistance(stoppingDistance);
            this.miningTask.Do(this);
        }

        public void OnComplete(Task task, bool saccess)
        {
            this.Return(saccess);
        }
    }
}