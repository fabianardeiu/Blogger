using BloggerCore.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.Commands.Posts
{
    public class CommentPostCommand : IRequest
    {
        public CommentDto CommentDto { get; set; }
    }
}
