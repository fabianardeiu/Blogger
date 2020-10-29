using BloggerCore.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.Queries.Posts
{
    public class GetAllPostsQuery : IRequest<IEnumerable<PostDto>>
    {
    }
}
