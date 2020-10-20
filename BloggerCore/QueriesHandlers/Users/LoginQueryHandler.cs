using AutoMapper;
using BloggerCore.Dtos;
using BloggerCore.Queries.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.QueriesHandlers.Users
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, PersonDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users
                .SingleOrDefaultAsync(u => u.Username == request.UserDto.Username
                && u.Password == request.UserDto.Password);

            if (user == null)
                return null;

            var person = await _unitOfWork.Persons.SingleOrDefaultAsync(p => p.UserId == user.Id);

            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }
    }
}
