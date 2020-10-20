using BloggerCore.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.Queries.Users
{
    public class LoginQuery : IRequest<PersonDto>
    {
        public UserDto UserDto { get; set; }
    }
}
