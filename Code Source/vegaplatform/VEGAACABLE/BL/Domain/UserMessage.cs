using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class UserMessage
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ViewedDate { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public virtual User User { get; set; }
        public virtual Message Message { get; set; }
        public state status { get; set; }
        public enum state
        {
            unread = 0,
            Viewed =1,
        }
    }
}
