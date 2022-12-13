using System;

namespace Homework_Components.Components
{
    public interface IOnDeathComponent
    {
        public event Action OnDeath;
    }
}