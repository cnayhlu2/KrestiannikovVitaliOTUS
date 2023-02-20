﻿using System;
using System.Collections.Generic;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Homework_11_Chests
{
    public class Chest
    {
        public Sprite Icon => this.chestConfig.GetIcon;
        public ChestType Type => this.chestConfig.ChestType;
        public List<RewardConfig> Rewards => this.chestConfig.Rewards;
        public float Duration => this.chestConfig.Duration;
        [ShowInInspector] public bool IsActive => this.countdown.IsPlaying;
        [ShowInInspector] public bool IsCompleted => this.isCompleted;

        [ShowInInspector] public float RemainingSeconds
        {
            get => this.countdown.RemainingTime;
            set => this.countdown.RemainingTime = value;
        }

        private readonly ChestConfig chestConfig;
        private readonly Countdown countdown;
        private bool isCompleted = false;

        public Chest(ChestConfig chestConfig, MonoBehaviour behaviour)
        {
            this.chestConfig = chestConfig;
            this.countdown = new Countdown(behaviour, chestConfig.Duration);
        }

        public void Start()
        {
            if (this.IsActive)
            {
                throw new Exception("Is started!");
            }

            this.isCompleted = false;
            this.countdown.OnEnded += this.OnEndTime;

            this.countdown.Reset();
            this.countdown.Play();
        }

        public void Reset()
        {
            this.isCompleted = false;
        }

        public Reward GetRandomReward()
        {
            var rndIndex = Random.Range(0, Rewards.Count);
            return Rewards[rndIndex].Reward;
        }
        
        private void OnEndTime()
        {
            this.isCompleted = true;
            this.countdown.OnEnded -= this.OnEndTime;
        }
    }
}