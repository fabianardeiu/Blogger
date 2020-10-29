using BloggerCore.Dtos;
using MediatR;
using System;

namespace BloggerCore.Commands.Posts
{
    public class CreatePostCommand : IRequest
    {
        public CreatePostDto CreatePostDto { get; set; }
    }
}
