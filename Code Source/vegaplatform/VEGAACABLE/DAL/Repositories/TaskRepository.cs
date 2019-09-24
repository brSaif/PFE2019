using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Repositories;
using Task = VEGAACABLE.BL.Domain.Task;

namespace VEGAACABLE.DAL.Repositories
{
    public class TaskRepository : Repository<Task>,ITaskRepository
    {
        public TaskRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Task> AllTasks()
        {
            var s = VegaContext.Tasks
                .OrderBy(c => c.Id)
                .OrderBy(c => c.Deadline)
                .ToList();
            return s;
        }

        public Task Find(int id)
        {
            return VegaContext.Tasks.Find(id);
        }

        public void InsertOrUpdate(Task task)
        {
            if (task.Id == default(int))
            {
                VegaContext.Tasks.Add(task);
            }
            else
            {
                VegaContext.Entry(task).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var task = VegaContext.Tasks.Find(id);
            VegaContext.Tasks.Remove(task);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
