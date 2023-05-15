using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sender.Application.Interfaces;
using Sender.Domain.Common.Commands;
using Sender.Domain.Common.Queries;
using Sender.Domain.Dtos;

namespace Sender.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator _validator;
        public SenderController(IMediator mediator, IValidator validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateReminder(CreateReminderRequest request)
        {
            var isValid = true;
            string errorMessage = "";
            if (request.Method == "email")
            {
                isValid = _validator.IsValidEmail(request.To);
                errorMessage = "Email is not valid!";
            }
            else
            {
                isValid = _validator.IsValidNumber(request.To);
                errorMessage = "Number is not valid!";
            }
            if (!isValid)
            {
               return BadRequest(errorMessage);
            }
            var command = new CreateCommand
            {
                To = request.To,
                Content = request.Content,
                SendAt = request.SendAt.ToUniversalTime(),
                Method = request.Method
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateReminder(UpdateReminderRequest request)
        {
            var isValid = true;
            string errorMessage = "";
            if (request.Method == "email")
            {
                isValid = _validator.IsValidEmail(request.To);
                errorMessage = "Email is not valid!";
            }
            else
            {
                isValid = _validator.IsValidNumber(request.To);
                errorMessage = "Number is not valid!";
            }
            if (!isValid)
            {
                return BadRequest(errorMessage);
            }
            var command = new UpdateCommand
            {
                Id = request.Id,
                To = request.To,
                Content = request.Content,
                SendAt = request.SendAt,
                Method = request.Method
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteReminder(DeleteReminderRequest request)
        {
            var command = new DeleteCommand
            {
                Ids = request.Ids
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("read")]
        public async Task<IActionResult> GetAllReminder()
        {
            var reminders = await _mediator.Send(new ReadCommand());

            return Ok(reminders);
        }
    }
}
