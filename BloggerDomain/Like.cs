using System;

namespace BloggerDomain
{
    public class Like : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
