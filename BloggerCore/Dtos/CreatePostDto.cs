using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.Dtos
{
    public class CreatePostDto
    {
        public Guid PersonId { get; set; }
        public byte[] Image { get; set; }
        public string Text { get; set; }
    }
}
