using Elementary;
using UnityEngine;

namespace Homework_08_Interaction.Components
{
    public class ConveyorTimeComponent : MonoBehaviour,IConveyorTimeComponent
    {
        [SerializeField] private MonoTimer timer;
        
        public void ReduceTime(float time)
        {
            timer.Duration = timer.Duration - time;
        }
    }
}