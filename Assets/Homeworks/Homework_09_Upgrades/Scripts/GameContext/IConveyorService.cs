using System.Collections.Generic;
using Entities;

namespace Homework_08_Interaction.GameContext
{
    public interface IConveyorService
    {
        IEntity GetConveyorById(string id);

        List<IEntity> GetAllConveyors();
    }
}