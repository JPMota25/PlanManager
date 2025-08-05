using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.PlanManager.CreatePlan;
using PlanManager.Aplication.Commands.PlanManager.Plan.PlanQuery;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Aplication.DTOs.Request.PlanManager;
using PlanManager.Aplication.DTOs.Request.PlanManager.Plan;

namespace PlanManager.Api.Controllers;

[ApiController]
[Route("api")]
public class PlanController : ControllerBase {
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public PlanController(IMapper mapper, IMediator mediator) {
		_mapper = mapper;
		_mediator = mediator;
	}

	[HttpPost("v1/plan")]
	public async Task<IActionResult> Create([FromBody] CreatePlanDto request) {
		var command = _mapper.Map<CreatePlanCommand>(request);
		var result = await _mediator.Send(command);
		return Ok(result);
	}

	[HttpPost("api/v1/plan")]
	public async Task<IActionResult> List([FromBody] PlanQueryDto request) {
		var command = _mapper.Map<PlanQueryCommand>(request);
		var response = await _mediator.Send(command);
		return Ok(response);
	}
}