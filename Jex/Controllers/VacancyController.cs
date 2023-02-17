using Jex.Application.Vacancies.Commands.CreateVacancy;
using Jex.Application.Vacancies.Commands.DeleteVacancy;
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
        public async Task<IActionResult> Get()
        {
            var companies = await _mediator.Send(new GetVacanciesQuery());
            return Ok(companies);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateVacancyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateVacancyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteVacancyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
