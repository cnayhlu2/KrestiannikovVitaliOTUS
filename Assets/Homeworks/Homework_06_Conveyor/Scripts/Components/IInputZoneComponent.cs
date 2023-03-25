namespace Homework_06_Conveyor.Components
{
    public interface IInputZoneComponent
    {
        bool CanUnload(Game.GameEngine.GameResources.ResourceType resourceType);
        int UnloadAll(Game.GameEngine.GameResources.ResourceType resourceType);
        
        void AddStorageLimit(int size);
    }
}