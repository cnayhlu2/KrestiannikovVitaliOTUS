namespace Homework_06_Conveyor.Components
{
    public interface IInputZoneComponent
    {
        bool CanUnload(ResourceType resourceType);
        int UnloadAll(ResourceType resourceType);
        
        void AddStorageLimit(int size);
    }
}