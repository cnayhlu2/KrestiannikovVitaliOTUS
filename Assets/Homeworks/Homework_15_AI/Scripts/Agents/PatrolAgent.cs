using System;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_15_AI.Agents
{
    public class PatrolAgent : Agent
    {
        [SerializeField] private MoveAgent moveAgent;

        [ShowInInspector] private Vector3[] moveList;
        private int moveListIndex;
        private float waiteTime;

        [ShowInInspector] private float time = 0;

        private void Update()
        {
            if (!IsPlaying)
                return;

            if (this.moveAgent.IsPlaying)
                return;

            if (this.time > waiteTime)
            {
                UpdateTargetPosition();
                this.moveAgent.Play();
                this.time = 0;
            }

            this.time += Time.deltaTime;
        }

        [Button]
        public void SetWaiteTime(float waiteTime)
        {
            this.waiteTime = waiteTime;
        }

        [Button]
        public void SetPatrolPoints(Vector3[] points)
        {
            this.moveList = points;
            this.moveListIndex = 0;
            UpdateTargetPosition();
        }

        [Button]
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.moveAgent.SetStoppingDistance(stoppingDistance);
        }

        [Button]
        public void SetUnit(IEntity unit)
        {
            this.moveAgent.SetUnit(unit);
        }

        protected override void OnPlay()
        {
            this.moveAgent.Play();
        }

        protected override void OnStop()
        {
            if (!this.moveAgent.IsPlaying)
                this.moveAgent.Stop();
        }

        private void UpdateTargetPosition()
        {
            if (this.moveListIndex >= this.moveList.Length)
                this.moveListIndex = 0;
            this.moveAgent.SetTargetPosition(this.moveList[this.moveListIndex]);
            this.moveListIndex++;
        }
    }
}