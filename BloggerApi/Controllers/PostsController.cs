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

        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> CommentPost([FromBody] CommentDto commentDto)
        {
            await _mediator.Send(new CommentPostCommand
            {
                CommentDto = commentDto
            });

            return Ok();
        }

        [HttpPost]
        [Route("like")]
        public async Task<IActionResult> LikePost([FromBody] LikeDto likeDto)
        {
            var action = await _mediator.Send(new LikePostCommand
            {
                LikeDto = likeDto
            });

            return Ok(action);
        }

        [HttpGet]
        [Route("{postId}/comment")]
        public async Task<IActionResult> GetPostComments(Guid postId)
        {
            var commentsDtos = await _mediator.Send(new GetPostCommentsQuery
            {
                PostId = postId
            });

            return Ok(commentsDtos);
        }
    }
}
