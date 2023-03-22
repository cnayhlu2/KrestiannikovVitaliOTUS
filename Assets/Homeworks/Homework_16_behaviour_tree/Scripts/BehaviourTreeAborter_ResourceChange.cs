using System;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Homeworks.Homework_16_behaviour_tree
{
    public class BehaviourTreeAborter_ResourceChange : MonoBehaviour
    {
        [SerializeField] private UnityBehaviourTree behaviourTree;
        [SerializeField] private UnityBlackboard blackboard;
        
        [Space] [BlackboardKey] [SerializeField]
        private string resourceLocationKey;

        private void OnEnable()
        {
            blackboard.OnVariableAdded += this.OnVariableChanged;
            blackboard.OnVariableChanged += this.OnVariableChanged;
            blackboard.OnVariableRemoved += this.OnVariableChanged;
        }

        private void OnDisable()
        {
            blackboard.OnVariableAdded -= this.OnVariableChanged;
            blackboard.OnVariableChanged -= this.OnVariableChanged;
            blackboard.OnVariableRemoved -= this.OnVariableChanged;
        }

        private void OnVariableChanged(string key, object value)
        {
            if (this.resourceLocationKey == key)
            {
                this.behaviourTree.Abort();
            }
        }
    }
}