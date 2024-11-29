using TechYatra.Model;

namespace TechYatra.Interface
{
    public interface IToDoService
    {
        ToDo AddTask(ToDo toDo);

        List<ToDo> GetAllTasks();

        ToDo GetTask(int taskId);

        ToDo UpdateTask(ToDo toDo);

        bool DeleteTask(int taskId);

        bool IsExists(int taskId);
    }
}
