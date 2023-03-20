using Elementary;
using Homework_Components.Components;
using UnityEngine;

namespace Homework_States.Components
{
    public class ShootComponent : MonoBehaviour, IShootComponent
    {
        [SerializeField] private MonoBoolVariable attacker;

        public void Shoot()
        {
            this.attacker.SetTrue();
        }
    }
}