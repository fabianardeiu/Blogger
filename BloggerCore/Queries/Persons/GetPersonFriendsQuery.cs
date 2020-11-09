using BloggerCore.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace BloggerCore.Queries.Persons
{
    public class GetPersonFriendsQuery : IRequest<IEnumerable<PersonDto>>
    {
        public Guid PersonId { get; set; }
    }
}
