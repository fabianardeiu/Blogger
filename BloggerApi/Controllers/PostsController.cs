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

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _mediator.Send(new GetAllPostsQuery());

            return Ok(result);
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
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            var postId = await _mediator.Send(new CreatePostCommand
            {
                CreatePostDto = createPostDto
            });

            return Ok(postId);
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

        [HttpDelete]
        [Route("{postId}")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            await _mediator.Send(new DeletePostCommand {
                PostId = postId
            });

            return Ok();
        }

        [HttpGet]
        [Route("{postId}")]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            var postDto = await _mediator.Send(new GetPostByIdQuery
            {
                PostId = postId
            });

            return Ok(postDto);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDto postDto)
        {
            await _mediator.Send(new UpdatePostCommand
            {
                PostDto = postDto
            });

            return Ok();
        }
    }
}
