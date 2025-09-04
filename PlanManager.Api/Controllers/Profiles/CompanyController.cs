using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.Profiles.Company.CreateCompany;
using PlanManager.Aplication.DTOs.Request.Profiles.Company;

namespace PlanManager.Api.Controllers.Profiles
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CompanyController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyDto request)
        {
            var command = _mapper.Map<CreateCompanyCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
