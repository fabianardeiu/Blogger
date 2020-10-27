using System;
using System.Collections.Generic;

namespace BloggerDomain
{
    public class Post : BaseEntity
    {
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
