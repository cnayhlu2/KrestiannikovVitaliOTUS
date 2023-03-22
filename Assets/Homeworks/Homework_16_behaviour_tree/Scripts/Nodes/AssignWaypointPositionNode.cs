using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class AssignWaypointPositionNode : BehaviourNode
    {
        [SerializeField] private UnityBlackboard blackboard;

        [Space] [BlackboardKey] [SerializeField]
        private string waypointKey;
        
        [Space] [BlackboardKey] [SerializeField]
        private string movePositionKey;
        
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(waypointKey, out IEnumerator<Vector3> waypoints))
            {
                this.Return(false);
                return;
            }

            Vector3 position = waypoints.Current;

            if (this.blackboard.HasVariable(this.movePositionKey))
            {
                this.blackboard.ChangeVariable(this.movePositionKey,position);
            }
            else
            {
                this.blackboard.AddVariable(this.movePositionKey,position);
            }

            this.Return(true);

        }
    }
}