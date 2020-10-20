using System.Threading.Tasks;
using AutoMapper;
using BloggerCore.Commands.Users;
using BloggerCore.Dtos;
using BloggerCore.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {

            var result = await _mediator.Send(new LoginQuery
            {
                UserDto = userDto
            });

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            await _mediator.Send(new RegisterCommand
            {
                RegisterUserDto = registerUserDto
            });

            return Ok();
        }
    }
}
