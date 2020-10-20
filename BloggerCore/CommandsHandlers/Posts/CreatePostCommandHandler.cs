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
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request.CreatePostDto);
            post.PersonId = request.PersonId;

            _unitOfWork.Posts.Add(post);
            await _unitOfWork.SaveChangesAsync();

            return default;
        }
    }
}
