using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class ShootMechanic : MonoBehaviour
    {
        [SerializeField, Required] private Transform attackPoint;
        [SerializeField, Required] private GameObject projectile;

        [Button("Shoot")]
        public void CreateProjectile()
        {
            Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        }

    }
}

