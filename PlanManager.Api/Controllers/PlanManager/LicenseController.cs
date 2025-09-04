using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.PlanManager.License.CreateLicense;
using PlanManager.Aplication.Commands.PlanManager.License.VerifyLicenseAuthencity;
using PlanManager.Aplication.DTOs.Request.PlanManager;
using PlanManager.Aplication.DTOs.Request.PlanManager.License;

namespace PlanManager.Api.Controllers.PlanManager;

[ApiController]
[Route("api/[controller]")]
public class LicenseController : ControllerBase {
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public LicenseController(IMapper mapper, IMediator mediator) {
		_mapper = mapper;
		_mediator = mediator;
	}

	[HttpPost("v1/create")]	
	public async Task<IActionResult> Create([FromBody] CreateLicenseDto request) {
		var command = _mapper.Map<CreateLicenseCommand>(request);
		var result = await _mediator.Send(command);
		return Ok(result);
	}

	[HttpPost("v1/generatejwt")]
	public async Task<IActionResult> Verify([FromBody] GenerateJwt request)
	{
		var command = _mapper.Map<GenerateLicenseCommand>(request);
		return Ok(await _mediator.Send(command));
	}
}
