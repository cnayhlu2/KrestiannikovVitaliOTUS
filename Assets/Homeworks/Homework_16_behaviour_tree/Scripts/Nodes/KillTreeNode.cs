using AI.Blackboards;
using AI.BTree;
using Entities;
using Homeworks.Homework_16_behaviour_tree.Tasks;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class KillTreeNode : UnityBehaviourNode, ITaskCallback
    {
        [SerializeField] private KillTreeTask killTreeTask;

        [SerializeField] private UnityBlackboard blackboard;
        
        [SerializeField] [BlackboardKey] private string unitKey;
        [SerializeField, BlackboardKey] private string resourceLocationKey;
        [SerializeField] [BlackboardKey] private string stoppingDistanceKey;
        
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.resourceLocationKey, out Transform resource))
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

            UnityEntityProxy proxy = resource.GetComponent<UnityEntityProxy>();
            
            this.killTreeTask.SetTree(proxy.Entity);
            this.killTreeTask.SetUnit(unit);
            this.killTreeTask.SetStoppingDistance(stoppingDistance);


            this.killTreeTask.Do(this);
        }

        public void OnComplete(Task task, bool saccess)
        {
            this.Return(saccess);
        }
    }
}