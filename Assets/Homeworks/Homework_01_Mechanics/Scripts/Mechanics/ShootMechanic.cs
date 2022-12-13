using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_Mechanics.Mechanics
{
    public class ShootMechanic : MonoBehaviour
    {
        [SerializeField] private EventReceiver attacker;
        [SerializeField, Required] private Transform attackPoint;
        [SerializeField, Required] private GameObject projectile;
        [SerializeField] float scatter = 5f;

        private void OnEnable()
        {
            attacker.OnEvent += CreateProjectile;
        }
        private void OnDisable()
        {
            attacker.OnEvent -= CreateProjectile;
        }

        private void CreateProjectile()
        {
            Vector3 scatterVector = new Vector3(Random.Range(-scatter, scatter), Random.Range(-scatter, scatter), Random.Range(-scatter, scatter));
            Quaternion scatterEngle = Quaternion.Euler(scatterVector+ attackPoint.rotation.eulerAngles);
            Instantiate(projectile, attackPoint.position, scatterEngle);
        }

    }
}

