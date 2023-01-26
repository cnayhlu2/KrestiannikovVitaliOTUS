using UnityEngine;

namespace Homework_08_Interaction.Components
{
    public class Component_GetObjectType : MonoBehaviour, IComponent_GetObjectType
    {
        public ObjectType ObjectType => this.objectType;

        [SerializeField] private ObjectType objectType;
    }
}