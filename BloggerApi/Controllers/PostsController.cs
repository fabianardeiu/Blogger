using System;
using System.Threading.Tasks;
using AutoMapper;
using BloggerCore.Commands.Posts;
using BloggerCore.Dtos;
using BloggerCore.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloggerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("person/{personId}")]
        public async Task<IActionResult> GetPersonPosts(Guid personId)
        {
            var result = await _mediator.Send(new GetPersonPostsQuery
            {
                PersonId = personId
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("{personId}")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto, Guid personId)
        {
            await _mediator.Send(new CreatePostCommand
            {
                PersonId = personId,
                CreatePostDto = createPostDto
            });

            return Ok();
        }
    }
}
