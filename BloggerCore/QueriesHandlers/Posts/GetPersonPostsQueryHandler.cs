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

        public GetPersonPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostDto>> Handle(GetPersonPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.Posts
                .Include(p => p.Person)
                .Where(p => p.PersonId == request.PersonId)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    CreatedAt = p.CreatedAt,
                    PersonName = p.Person.FirstName + " " + p.Person.LastName,
                    PersonId = p.PersonId,
                    PersonImage = p.Person.Image,
                    Image = p.Image,
                    Text = p.Text,
                    LikesCount = p.Likes.Count,
                    CommentsCount = p.Comments.Count
                })
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return posts;
        }
    }
}
