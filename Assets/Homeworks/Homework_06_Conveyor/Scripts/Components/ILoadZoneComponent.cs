namespace Homework_06_Conveyor.Components
{
    public interface ILoadZoneComponent
    {
        bool CanLoad(Game.GameEngine.GameResources.ResourceType resourceType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="count"></param>
        /// <returns>count of not loaded resources</returns>
        int TryLoad(Game.GameEngine.GameResources.ResourceType resourceType, int count);

        void AddStorageLimit(int size);
    }
}