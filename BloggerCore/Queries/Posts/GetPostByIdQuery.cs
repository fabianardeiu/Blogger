using BloggerCore.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.Queries.Posts
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public Guid PostId { get; set; }
    }
}
