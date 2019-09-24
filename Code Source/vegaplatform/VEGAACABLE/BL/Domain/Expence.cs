using System;

namespace VEGAACABLE.BL.Domain
{
    public class Expence
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual ExpenceCat ExpenceCat { get; set; }
        public float Payment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int  UserId { get; set; }
        public int ExpenceCatId { get; set; }
        public string Description { get; set; }
    }
}
