using System;

namespace BloggerCore.Dtos
{
    public class CommentDto
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public Guid PersonId { get; set; }
        public string PersonName { get; set; }
        public byte[] PersonImage { get; set; }
    }
}
