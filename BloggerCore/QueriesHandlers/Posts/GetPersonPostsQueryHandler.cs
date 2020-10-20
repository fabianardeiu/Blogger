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
    public class GetPersonPostsQueryHandler : IRequestHandler<GetPersonPostsQuery, IEnumerable<PostDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostDto>> Handle(GetPersonPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.Posts
                .Where(p => p.PersonId == request.PersonId)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Image = p.Image,
                    Text = p.Text,
                    Likes = p.Likes.Select(l => new LikeDto { PostId = l.PostId, PersonName = l.Person.FirstName + " " + l.Person.LastName }).ToList(),
                    Comments = p.Comments.Select(c => new CommentDto {PostId = c.PostId, Text = c.Text, PersonName = c.Person.FirstName + " " + c.Person.LastName }).ToList()
                })
                .ToListAsync();

            return posts;
        }
    }
}
