﻿using DevineShop.Application.Common;
using DevineShop.Application.Handlers.CommentHandler.Commands.Create;
using DevineShop.Application.Handlers.CommentHandler.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevineShop.API.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Respond>> Create([FromBody] CreateCommentCommand command) => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<ActionResult> GetByBlogPostId(int blogPostId)
        {
            var query = new GetCommentByBlogPostIdQuery() { Id = blogPostId };
            return Ok(await _mediator.Send(query));
        }
    }
}
