using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homework_11_Chests
{
    [Serializable]
    public sealed class Reward
    {
        [SerializeField, PreviewField] private Sprite icon;
        [SerializeField] private string id;
        [Space, SerializeReference] private List<object> components;

        public Sprite Icon => icon;
        public string Id => id;

        public Reward()
        {
            this.id = string.Empty;
            this.components = new List<object>();
        }

        public Reward(string id, List<object> components)
        {
            this.id = id;
            this.components = new List<object>(components);
        }


        public List<T> GetComponents<T>()
        {
            List<T> result = new List<T>();
            for (int i = 0; i < this.components.Count; i++)
            {
                if (this.components[i] is T component)
                {
                    result.Add(component);
                }
            }

            return result;
        }

        public List<object> GetAllComponents() => this.components;

        public bool TryGetComponent<T>(out T result)
        {
            for (int i = 0; i < this.components.Count; i++)
            {
                if (this.components[i] is T component)
                {
                    result = component;
                    return true;
                }
            }

            result = default;
            return false;
        }
    }
}