using InstaBot.Application.DTOs;
using InstaBot.ProducerAPI.Commands;
using InstaBot.ProducerAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InstaBot.ProducerAPI.Controllers
{
    public class InstagramController : BaseController
    {
        private readonly ILogger<InstagramController> _logger;
        private readonly IMediator _mediator;

        public InstagramController(ILogger<InstagramController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> NewUserComingIn(NewUsernameComingInCommand command)
        {
            var id = Guid.NewGuid();
            try
            {              
                command.Id = id;
                await _mediator.Send(command);

                return StatusCode(StatusCodes.Status201Created, new NewPostResponse
                {
                    Id = command.Id,
                    Message = "New post creation request completed successfully!"
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.Log(LogLevel.Warning, ex, "Client made a bad request!");
                return BadRequest(new BaseResponse
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to create a new post!";
                _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

                return StatusCode(StatusCodes.Status500InternalServerError, new NewPostResponse
                {
                    Id = id,
                    Message = SAFE_ERROR_MESSAGE
                });
            }
        }
    }
}
