using BloggerCore.Dtos;
using BloggerCore.Queries.Persons;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.QueriesHandlers.Persons
{
    public class GetPersonFriendsQueryHandler : IRequestHandler<GetPersonFriendsQuery, IEnumerable<PersonDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonFriendsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonDto>> Handle(GetPersonFriendsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<PersonDto>();

            var friendsIds = await _unitOfWork.Friends
                .Where(f => f.PersonId == request.PersonId)
                .Select(f => f.FriendId)
                .ToListAsync();

            foreach (var friendId in friendsIds)
            {
                result.Add(GetFriend(friendId));
            }

            return result;
        }

        private PersonDto GetFriend(Guid friendId)
        {
            var friend = _unitOfWork.Persons.SingleOrDefault(p => p.Id == friendId);

            return new PersonDto
            {
                FirstName = friend.FirstName,
                LastName = friend.LastName,
                Image = friend.Image
            };
        }
    }
}
