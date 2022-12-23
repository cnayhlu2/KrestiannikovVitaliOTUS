using GameElements;

namespace Homework_05_Save_Load.Application
{
    public interface IGameDataLoader
    {
        void LoadData(IGameContext context);
    }
}