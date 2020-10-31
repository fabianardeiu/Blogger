using System;
using System.Collections;
using System.Collections.Generic;

namespace BloggerDomain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Friend> Friends { get; set; }
    }
}
