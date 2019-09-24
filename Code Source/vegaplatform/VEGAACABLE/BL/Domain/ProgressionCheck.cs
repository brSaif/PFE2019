using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class ProgressionCheck
    {
        public int ID { get; set; }
        public int OFID { get; set; }
        public int SeqID { get; set; }
        public Progression Progress { get; set; }
        public FabricationOrder FabricationOrder { get; set; }
        public Sequence Sequence { get; set; }
        public enum Progression
        {
            NotStarted = 0,
            InProgress = 1,
            Finished = 2
        }
    }
}
