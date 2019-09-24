using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = VEGAACABLE.BL.Domain.Task;

namespace VEGAACABLE.BL.Repositories
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<Task> AllTasks();
        Task Find(int id);
        void InsertOrUpdate(Task task);
        void Delete(int id);
    }
}
