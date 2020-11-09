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
    public class AddFriendCommandHandler : IRequestHandler<AddFriendCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddFriendCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddFriendCommand request, CancellationToken cancellationToken)
        {
            //var person = await _unitOfWork.Persons.SingleOrDefaultAsync(p => p.Id == request.AddFriendDto.PersonId);
            //var friend = await _unitOfWork.Persons.SingleOrDefaultAsync(p => p.Id == request.AddFriendDto.FriendId);

            _unitOfWork.Friends.Add(new Friend { PersonId = request.AddFriendDto.PersonId, FriendId = request.AddFriendDto.FriendId });


            //_unitOfWork.Friends.Add(new Friend { PersonId = person.Id, Person = friend });
            await _unitOfWork.SaveChangesAsync();

            return default;
        }
    }
}
