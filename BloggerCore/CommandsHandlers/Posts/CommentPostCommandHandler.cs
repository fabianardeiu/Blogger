using AutoMapper;
using BloggerCore.Commands.Posts;
using BloggerDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.CommandsHandlers.Posts
{
    public class CommentPostCommandHandler : IRequestHandler<CommentPostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentPostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CommentPostCommand request, CancellationToken cancellationToken)
        {
            var comment = _mapper.Map<Comment>(request.CommentDto);

            _unitOfWork.Comments.Add(comment);
            await _unitOfWork.SaveChangesAsync();

            return default;
        }
    }
}
