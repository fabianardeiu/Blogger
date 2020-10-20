using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerDomain
{
    public class Friend : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
