using System;
using System.Collections.Generic;

namespace BloggerCore.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public Guid PersonId { get; set; }
        public string PersonName { get; set; }
        public byte[] PersonImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
    }
}
