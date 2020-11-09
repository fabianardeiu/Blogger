using BloggerCore.Dtos;
using MediatR;

namespace BloggerCore.Commands.Persons
{
    public class AddFriendCommand : IRequest<bool>
    {
        public AddFriendDto AddFriendDto { get; set; }
    }
}
