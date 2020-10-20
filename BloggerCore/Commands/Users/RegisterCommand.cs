using BloggerCore.Dtos;
using MediatR;

namespace BloggerCore.Commands.Users
{
    public class RegisterCommand : IRequest
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }
}
