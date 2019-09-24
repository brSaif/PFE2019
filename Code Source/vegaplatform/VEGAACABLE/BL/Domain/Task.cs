
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public status Status { get; set; }
        public virtual ICollection<UGroup> Groups { get; set; }
        public enum status : byte
        {
            Launched = 1,
            Progressing = 2,
            Finished = 3
        }
    }
}
