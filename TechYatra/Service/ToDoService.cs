

using TechYatra.Context;
using TechYatra.Interface;
using TechYatra.Model;

namespace TechYatra.Service
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoContext _context;

        public ToDoService(ToDoContext context)
        {
            _context = context;
        }
        public ToDo AddTask(ToDo toDo)
        {
            var result=_context.ToDos.Add(toDo);
            _context.SaveChanges();
            return result.Entity;
        }

        public bool DeleteTask(int taskId)
        {
            var task = GetTask(taskId);
            if(task is null)
            {
                return false;
            }

            _context.ToDos.Remove(task);
            _context.SaveChanges();
            return true;
        }

        public List<ToDo> GetAllTasks()
        {
            var tasks =_context.ToDos.ToList();
            return tasks;
        }

        public ToDo GetTask(int taskId)
        {
            var task= _context.ToDos.FirstOrDefault(t=>t.Id== taskId);
            return task;
        }

        public ToDo UpdateTask(ToDo toDo)
        {
            if(IsExists(toDo.Id))
            {
                _context.Update(toDo);
                _context.SaveChanges();
                return toDo;
            }

            else
            {
                throw new Exception("Update the valid data");
            }
        }

        public bool IsExists(int taskId)
        {
            var entity = GetTask(taskId);
            return entity != null;
        }
    }
}
