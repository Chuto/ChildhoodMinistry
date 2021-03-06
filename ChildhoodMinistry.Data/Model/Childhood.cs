﻿using System.Collections.Generic;

namespace ChildhoodMinistry.Data.Model
{
    public class Childhood : BaseEntity
    {
        public int Number { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}
