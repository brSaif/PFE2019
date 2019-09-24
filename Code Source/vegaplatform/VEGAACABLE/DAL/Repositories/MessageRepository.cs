using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEGAACABLE.BL.Domain;
using VEGAACABLE.BL.Repositories;

namespace VEGAACABLE.DAL.Repositories
{
    public class MessageRepository : Repository<Message>,IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Message> AllMessages()
        {
            var s = VegaContext.Messages
                .OrderBy(c => c.Id)
                .OrderBy(c => c.Title)
                .ToList();
            return s;
        }

        public Message Find(int id)
        {
            return VegaContext.Messages.Find(id);
        }

        public void InsertOrUpdate(Message message)
        {
            if (message.Id == default(int))
            {
                VegaContext.Messages.Add(message);
            }
            else
            {
                VegaContext.Entry(message).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var message = VegaContext.Messages.Find(id);
            VegaContext.Messages.Remove(message);
        }
        public VegaContext VegaContext
        {
            get { return Context as VegaContext; }
        }
    }
}
