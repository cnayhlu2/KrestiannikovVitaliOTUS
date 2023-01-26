using System;
using UnityEngine;

namespace Homework_08_Interaction.Components
{
    public interface IComponent_CollisionEvents
    {
        event Action<Collision> OnCollisionEntered;
        event Action<Collision> OnCollisionStaying;
        event Action<Collision> OnCollisionExited;
    }
}