using Homework_11_Chests;

namespace Homeworks.Homework_12_Real_Time.Scripts
{
    public sealed class ChestSynchronizer : ITimeSynchronizer
    {
        private ChestManager chestManager;

        public void Construct(ChestManager chestManager)
        {
            this.chestManager = chestManager;
        }
        
        public void TimePassed(float time)
        {
            foreach (Chest chest in this.chestManager.GetChests)
            {
                chest.RemainingSeconds -= time;
            }
        }
    }
}