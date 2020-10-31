using BloggerCore.Dtos;
using MediatR;

namespace BloggerCore.Commands.Persons
{
    public class UpdatePofileCommand : IRequest
    {
        public PersonDto PersonDto { get; set; }
    }
}
