using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.PlanManager.PlanPermission.CreatePlanPermission;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Aplication.DTOs.Request.PlanManager;

namespace PlanManager.Api.Controllers;

[ApiController]
[Route("api")]
public class PlanPermissionRelationController : ControllerBase {
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public PlanPermissionRelationController(IMapper mapper, IMediator mediator) {
		_mapper = mapper;
		_mediator = mediator;
	}

	[HttpPost("v1/PlanPermissionRelation")]
	public async Task<IActionResult> AddPermissionOnPlan([FromBody] CreatePlanPermissionRelationDto request) {
		var command = _mapper.Map<CreatePlanPermissionCommand>(request);
		var result = await _mediator.Send(command);
		return Ok(result);
	}
}