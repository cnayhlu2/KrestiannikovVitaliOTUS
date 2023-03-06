using Elementary;
using UnityEngine;

namespace Homework_08_Interaction.Components
{
    public class Componen_IsDeath : MonoBehaviour, IComponen_IsDeath
    {
        [SerializeField] private MonoBoolVariable isDeath;

        public bool IsDeath => isDeath.Value;
    }
}