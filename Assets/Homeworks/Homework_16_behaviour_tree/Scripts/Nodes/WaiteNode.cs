using AI.Blackboards;
using AI.BTree;
using Homeworks.Homework_16_behaviour_tree.Tasks;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class WaiteNode : UnityBehaviourNode,ITaskCallback
    {
        [SerializeField] private WaiteTask waiteTask;

        [SerializeField] private UnityBlackboard blackboard;

        [SerializeField] [BlackboardKey] private string waiteTimeKey;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.waiteTimeKey, out float waiteTime))
            {
                this.Return(false);
                return;
            }
            
            this.waiteTask.SetDuration(waiteTime);
            this.waiteTask.Do(this);
        }

        protected override void OnAbort()
        {
            this.waiteTask.Cansel();
        }

        void ITaskCallback.OnComplete(Task task, bool saccess)
        {
            this.Return(saccess);
        }
    }
}