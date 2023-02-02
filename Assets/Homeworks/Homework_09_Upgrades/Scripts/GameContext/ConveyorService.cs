using System;
using System.Collections.Generic;
using Entities;
using Homework_08_Interaction.Components;
using UnityEngine;

namespace Homework_08_Interaction.GameContext
{
    public class ConveyorService : MonoBehaviour, IConveyorService
    {
        [SerializeField] private List<UnityEntityBase> conveyors;

        IEntity IConveyorService.GetConveyorById(string id)
        {
            for (int i = 0; i < this.conveyors.Count; i++)
            {
                if (this.conveyors[i].Get<IIDComponent>().GetId() == id)
                    return this.conveyors[i];
            }

            throw new Exception("Unknown id");
        }

        List<IEntity> IConveyorService.GetAllConveyors()
        {
            List<IEntity> result = new();

            foreach (var conveyor in conveyors)
            {
                result.Add(conveyor);
            }

            return result;
        }
    }
    
}