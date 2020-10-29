using BloggerCore.Dtos;
using MediatR;

namespace BloggerCore.Commands.Posts
{
    public class UpdatePostCommand : IRequest
    {
        public UpdatePostDto PostDto { get; set; }
    }
}
