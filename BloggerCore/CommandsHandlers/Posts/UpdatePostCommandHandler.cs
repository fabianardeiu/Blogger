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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Posts.FirstOrDefaultAsync(p => p.Id == request.PostDto.Id);

            post.Text = request.PostDto.Text;
            post.Image = request.PostDto.Image;

            _unitOfWork.Posts.Update(post);
            await _unitOfWork.SaveChangesAsync();

            return default;
        }
    }
}
