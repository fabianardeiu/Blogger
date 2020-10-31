using BloggerCore.Dtos;
using MediatR;
using System;

namespace BloggerCore.Commands.Posts
{
    public class CreatePostCommand : IRequest<Guid>
    {
        public CreatePostDto CreatePostDto { get; set; }
    }
}
