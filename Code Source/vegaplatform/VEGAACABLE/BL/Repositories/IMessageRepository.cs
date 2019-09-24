using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;

namespace VEGAACABLE.BL.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> AllMessages();
        Message Find(int id);
        void InsertOrUpdate(Message message);
        void Delete(int id);
    }
}
