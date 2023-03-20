namespace Homeworks.Homework_16_behaviour_tree.Tasks
{
    public interface ITaskCallback
    {
        void OnComplete(Task task, bool saccess);
    }
}