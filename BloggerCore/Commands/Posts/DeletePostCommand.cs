using MediatR;
using System;

namespace BloggerCore.Commands.Posts
{
    public class DeletePostCommand : IRequest
    {
        public Guid PostId { get; set; }
    }
}
