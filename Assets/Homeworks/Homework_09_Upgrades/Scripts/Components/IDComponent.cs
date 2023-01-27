using UnityEngine;

namespace Homework_08_Interaction.Components
{
    public class IDComponent : MonoBehaviour,IIDComponent
    {
        [SerializeField] private string id;
        
        
        string IIDComponent.GetId()
        {
            return id;
        }
    }
}