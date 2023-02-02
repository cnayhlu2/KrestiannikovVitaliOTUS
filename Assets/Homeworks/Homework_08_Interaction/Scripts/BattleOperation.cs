using Entities;

namespace Homework_08_Interaction
{
    public class BattleOperation
    {
        public readonly IEntity Enemy;
        
        public bool isCompleted;

        public BattleOperation(IEntity enemy)
        {
            this.Enemy = enemy;
        }
    }
}