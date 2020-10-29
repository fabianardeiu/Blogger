using BloggerCore.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace BloggerCore.Queries.Posts
{
    public class GetPostCommentsQuery : IRequest<IEnumerable<CommentDto>>
    {
        public Guid PostId { get; set; }
    }
}
