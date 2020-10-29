using BloggerCore.Dtos;
using MediatR;

namespace BloggerCore.Commands.Posts
{
    public class LikePostCommand : IRequest<bool>
    {
        public LikeDto LikeDto { get; set; }
    }
}
