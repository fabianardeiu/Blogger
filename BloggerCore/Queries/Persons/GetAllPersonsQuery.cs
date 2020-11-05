using BloggerCore.Dtos;
using MediatR;
using System.Collections.Generic;

namespace BloggerCore.Queries.Persons
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }
}
