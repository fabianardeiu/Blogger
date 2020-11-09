using BloggerCore.Commands.Persons;
using BloggerDomain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.CommandsHandlers.Persons
{
    public class AddFriendCommandHandler : IRequestHandler<AddFriendCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddFriendCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddFriendCommand request, CancellationToken cancellationToken)
        {
            var alreadyFriends = _unitOfWork.Friends.Any(f => f.PersonId == request.AddFriendDto.PersonId && f.FriendId == request.AddFriendDto.FriendId);

            if (alreadyFriends)
                return false;

            _unitOfWork.Friends.Add(new Friend { PersonId = request.AddFriendDto.PersonId, FriendId = request.AddFriendDto.FriendId });

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
