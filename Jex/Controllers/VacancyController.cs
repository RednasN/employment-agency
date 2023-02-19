using Jex.Application.Vacancies.Commands.CreateVacancy;
using Jex.Application.Vacancies.Commands.DeleteVacancy;
using Jex.Application.Vacancies.Models;
using Jex.Application.Vacancy.Commands.UpdateVacancy;
using Jex.Application.Vacancy.Queries.GetVacancy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Jex.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VacancyController : Controller
    {
        private readonly IMediator _mediator;
        public VacancyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VacancyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var companies = await _mediator.Send(new GetVacanciesQuery());
            return Ok(companies);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateVacancyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateVacancyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete([FromQuery] DeleteVacancyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
