using System;

namespace BloggerDomain
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
