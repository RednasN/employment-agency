using Jex.Application.Companies.Commands;
using Jex.Application.Companies.Commands.CreateCompany;
using Jex.Application.Companies.Commands.DeleteCompany;
using Jex.Application.Companies.Commands.UpdateCompany;
using Jex.Application.Companies.Queries.GetCompanies;
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
        public async Task<IActionResult> Get([FromQuery] GetCompaniesQuery query)
        {
            var companies = await _mediator.Send(query);
            return Ok(companies);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCompanyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteCompanyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
