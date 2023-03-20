using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Homework_Mechanics.Mechanics
{
    public class TakeDamageMechanic : MonoBehaviour
    {
        [SerializeField, Required] private EventReceiver_Int takeDamage;
        [SerializeField, Required] private MonoIntVariableLimited hitPoints;

        private void OnEnable()
        {
            takeDamage.OnEvent += OnTakeDamage;
        }

        private void OnDisable()
        {
            takeDamage.OnEvent -= OnTakeDamage;
        }

        private void OnTakeDamage(int damage)
        {
            hitPoints.Value -= damage;
        }

    }
}


