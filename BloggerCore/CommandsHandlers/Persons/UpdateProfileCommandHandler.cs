using AutoMapper;
using BloggerCore.Commands.Persons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore.CommandsHandlers.Persons
{
    public class UpdateProfileCommandHandler : IRequestHandler<UpdatePofileCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePofileCommand request, CancellationToken cancellationToken)
        {
            var personToUpdate = _unitOfWork.Persons.FirstOrDefault(p => p.Id == request.PersonDto.Id);

            personToUpdate.FirstName = request.PersonDto.FirstName;
            personToUpdate.LastName = request.PersonDto.LastName;
            personToUpdate.Image = request.PersonDto.Image;

            _unitOfWork.Persons.Update(personToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return default;

        }
    }
}
