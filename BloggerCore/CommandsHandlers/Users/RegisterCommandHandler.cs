using BloggerCore.Commands.Users;
using BloggerDomain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.CommandsHandlers.Users
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.RegisterUserDto.Username,
                Password = request.RegisterUserDto.Password
            };

            _unitOfWork.Users.Add(user);

            var person = new Person
            {
                FirstName = request.RegisterUserDto.FirstName,
                LastName = request.RegisterUserDto.LastName,
                UserId = user.Id,
            };
            _unitOfWork.Persons.Add(person);

            await _unitOfWork.SaveChangesAsync();

            return default;
        }
    }
}
