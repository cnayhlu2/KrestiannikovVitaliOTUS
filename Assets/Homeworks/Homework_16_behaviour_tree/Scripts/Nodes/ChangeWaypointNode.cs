using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree.Nodes
{
    public class ChangeWaypointNode : BehaviourNode
    {
        [SerializeField] private UnityBlackboard blackboard;

        [Space] [BlackboardKey] [SerializeField]
        private string waypointKey;
        
        protected override void Run()
        {
            if (this.blackboard.TryGetVariable(waypointKey, out IEnumerator<Vector3> waypoints))
            {
                waypoints.MoveNext();
                this.Return(true);
                return;
            }
            
            this.Return(false);
        }
    }
}