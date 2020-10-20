using System;
using System.Collections.Generic;

namespace BloggerCore.Dtos
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
        public ICollection<LikeDto> Likes { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
