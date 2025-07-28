using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.CreateLicense;
using PlanManager.Aplication.DTOs.Request.PlanManager;

namespace PlanManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LicenseController : ControllerBase {
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public LicenseController(IMapper mapper, IMediator mediator) {
		_mapper = mapper;
		_mediator = mediator;
	}

	[HttpPost("v1/license")]
	public async Task<IActionResult> Create([FromBody] CreateLicenseDto request) {
		var command = _mapper.Map<CreateLicenseCommand>(request);
		var result = await _mediator.Send(command);
		return Ok(result);
	}
}