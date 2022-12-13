using GameElements;

namespace Homework_05_Save_Load.Application
{
    public interface IGameDataSaver
    {
        void Save(IGameContext context);
    }
}