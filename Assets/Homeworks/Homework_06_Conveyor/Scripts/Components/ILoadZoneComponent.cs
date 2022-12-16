namespace Homework_06_Conveyor.Components
{
    public interface ILoadZoneComponent
    {
        bool CanLoad(ResourceType resourceType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="count"></param>
        /// <returns>count of not loaded resources</returns>
        int TryLoad(ResourceType resourceType, int count);
    }
}