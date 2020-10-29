using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.Dtos
{
    public class CommentDto
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
        public Guid PersonId { get; set; }
        public string PersonName { get; set; }
    }
}
