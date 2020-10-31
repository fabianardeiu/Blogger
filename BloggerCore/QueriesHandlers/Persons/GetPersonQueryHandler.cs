using AutoMapper;
using BloggerCore.Dtos;
using BloggerCore.Queries.Persons;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.QueriesHandlers.Persons
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPersonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Persons.FirstOrDefaultAsync(p => p.Id == request.PersonId);
            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }
    }
}
