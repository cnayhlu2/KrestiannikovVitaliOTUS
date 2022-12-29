using Elementary;
using Homework_States.Animation;
using UnityEngine;

namespace Homework_States.State
{
    public class ShootingState : State
    {
        [SerializeField] private AnimationSystem animationSystem;

        [SerializeField] private string createProjectileKey;
        [SerializeField] private string shootingEnd;

        [SerializeField] private BoolBehaviour attacker;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private GameObject projectile;

        public override void Enter()
        {
            Debug.Log("Enter");
            this.animationSystem.OnEventReceived += OnEventReceived;
        }


        public override void Exit()
        {
            Debug.Log("Enter");
            this.animationSystem.OnEventReceived -= OnEventReceived;
        }

        private void OnEventReceived(string key)
        {
            Debug.Log($"OnEventReceived {key}");
            if (createProjectileKey == key)
            {
                Shoot();
            }
            else if (key == shootingEnd)
            {
                StopShoot();
            }
        }

        private void StopShoot()
        {
            this.attacker.AssignFalse();
        }

        private void Shoot()
        {
            Instantiate(projectile, attackPoint.position, Quaternion.identity);
        }
    }
}