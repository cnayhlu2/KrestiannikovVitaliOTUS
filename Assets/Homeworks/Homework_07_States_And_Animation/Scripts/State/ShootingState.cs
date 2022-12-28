using Homework_States.Animation;
using UnityEngine;

namespace Homework_States.State
{
    public class ShootingState : State
    {
        [SerializeField] private AnimationSystem animationSystem;

        [SerializeField] private string createProjectileKey = "";

        [SerializeField] private Transform attackPoint;
        [SerializeField] private GameObject projectile;

        public override void Enter()
        {
            this.animationSystem.OnEventReceived += OnEventReceived;
        }


        public override void Exit()
        {
            this.animationSystem.OnEventReceived += OnEventReceived;
        }


        private void OnEventReceived(string key)
        {
            if (createProjectileKey == key)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(projectile, attackPoint.position, Quaternion.identity);
        }
    }
}