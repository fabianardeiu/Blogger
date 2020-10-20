using BloggerCore.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.Queries.Posts
{
    public class GetPersonPostsQuery : IRequest<IEnumerable<PostDto>>
    {
        public Guid PersonId { get; set; }
    }
}
