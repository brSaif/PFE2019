﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGAACABLE.BL.Domain
{
    public class UPermission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UGroupPermission> GroupPermissions { get; set; }
    }
}

