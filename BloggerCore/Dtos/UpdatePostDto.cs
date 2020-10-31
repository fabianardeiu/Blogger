using System;

namespace BloggerCore.Dtos
{
    public class UpdatePostDto
    {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
    }
}
