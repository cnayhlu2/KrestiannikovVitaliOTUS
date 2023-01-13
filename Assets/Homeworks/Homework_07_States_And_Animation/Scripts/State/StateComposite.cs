using System.Collections.Generic;
using UnityEngine;

namespace Homework_States.State
{
    public sealed class StateComposite : State
    {
        [SerializeField] private List<State> states = new();

        public override void Enter()
        {
            foreach (State state in states)
            {
                state.Enter();
            }
        }

        public override void Exit()
        {
            foreach (State state in states)
            {
                state.Exit();
            }
        }
    }
}