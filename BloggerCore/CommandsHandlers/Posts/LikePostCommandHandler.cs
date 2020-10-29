using AutoMapper;
using BloggerCore.Commands.Posts;
using BloggerDomain;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.CommandsHandlers.Posts
{
    public class LikePostCommandHandler : IRequestHandler<LikePostCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LikePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            var existingLike = _unitOfWork.Likes
                .FirstOrDefault(l => l.PersonId == request.LikeDto.PersonId 
                                && l.PostId == request.LikeDto.PostId);
            if (existingLike != null)
            {
                _unitOfWork.Likes.Remove(existingLike);
                await _unitOfWork.SaveChangesAsync();
                return false;
            }
            else
            {
                var like = _mapper.Map<Like>(request.LikeDto);
                _unitOfWork.Likes.Add(like);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
        }
    }
}
