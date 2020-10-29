using BloggerCore.Commands.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.CommandsHandlers.Posts
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = _unitOfWork.Posts
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefault(p => p.Id == request.PostId);

            if (post == null)
                return default;

            foreach(var comment in post.Comments)
            {
                _unitOfWork.Comments.Remove(comment);
            }

            foreach (var like in post.Likes)
            {
                _unitOfWork.Likes.Remove(like);
            }
            await _unitOfWork.SaveChangesAsync();

            _unitOfWork.Posts.Remove(post);
            await _unitOfWork.SaveChangesAsync();

            return default;
        }
    }
}
