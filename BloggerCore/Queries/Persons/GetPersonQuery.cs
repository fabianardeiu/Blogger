using BloggerCore.Dtos;
using MediatR;
using System;

namespace BloggerCore.Queries.Persons
{
    public class GetPersonQuery : IRequest<PersonDto>
    {
        public Guid PersonId { get; set; }
    }
}
