using AutoMapper;
using BloggerCore.Commands.Persons;
using BloggerCore.Dtos;
using BloggerCore.Queries.Persons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BloggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("update-profile")]
        public async Task<IActionResult> UpdatePofile([FromBody] PersonDto personDto)
        {
            await _mediator.Send(new UpdatePofileCommand
            {
                PersonDto = personDto
            });

            return Ok();
        }

        [HttpGet]
        [Route("{personId}")]
        public async Task<IActionResult> GetPersonById(Guid personId)
        {
            var personDto = await _mediator.Send(new GetPersonQuery { PersonId = personId });

            return Ok(personDto);
        }
    }
}
