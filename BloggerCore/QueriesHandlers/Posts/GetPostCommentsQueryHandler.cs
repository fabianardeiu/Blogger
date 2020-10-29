using AutoMapper;
using BloggerCore.Dtos;
using BloggerCore.Queries.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.QueriesHandlers.Posts
{
    public class GetPostCommentsQueryHandler : IRequestHandler<GetPostCommentsQuery, IEnumerable<CommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetPostCommentsQuery request, CancellationToken cancellationToken)
        {
            var commentsDtos = await _unitOfWork.Comments
                .Include(c => c.Person)
                .Where(c => c.PostId == request.PostId)
                .Select(c => _mapper.Map<CommentDto>(c))
                .ToListAsync();

            return commentsDtos;
        }
    }
}
