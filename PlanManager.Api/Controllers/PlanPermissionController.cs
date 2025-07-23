using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.CreatePlanPermission;
using PlanManager.Aplication.DTOs.Request;

namespace PlanManager.Api.Controllers;

[ApiController]
[Route("api")]
public class PlanPermissionController : ControllerBase {
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public PlanPermissionController(IMediator mediator, IMapper mapper) {
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpPost("v1/planpermission")]
	public async Task<IActionResult> Create([FromBody] PlanPermissionDto request) {
		var command = _mapper.Map<CreatePlanPermissionCommand>(request);
		var result = await _mediator.Send(command);
		return Ok(result);
	}
}