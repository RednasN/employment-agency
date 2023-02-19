using Jex.Application.Companies.Commands;
using Jex.Application.Companies.Commands.CreateCompany;
using Jex.Application.Companies.Commands.DeleteCompany;
using Jex.Application.Companies.Commands.UpdateCompany;
using Jex.Application.Companies.Models;
using Jex.Application.Companies.Queries.GetCompanies;
using Jex.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Jex.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {        
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] GetCompaniesQuery query)
        {
            var companies = await _mediator.Send(query);
            return Ok(companies);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCompanyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete([FromQuery] DeleteCompanyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
