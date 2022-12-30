using System;
using Elementary;
using UnityEngine;

namespace Homework_States.Core
{
    public class ShootMechanic : MonoBehaviour
    {
        [SerializeField] private EventReceiver shoot;

        [SerializeField] private Transform attackPoint;
        [SerializeField] private GameObject projectile;
        
        private void OnEnable()
        {
            this.shoot.OnEvent += CreateArrow;
        }

        private void OnDisable()
        {
            this.shoot.OnEvent -= CreateArrow;
        }

        private void CreateArrow()
        {
            Instantiate(projectile, attackPoint.position, Quaternion.identity);
        }
    }
}