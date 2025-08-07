using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.PlanManager.Sign.CreateSign;
using PlanManager.Aplication.DTOs.Request.PlanManager;

namespace PlanManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SignController : ControllerBase {
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	public SignController(IMapper mapper, IMediator mediator) {
		_mapper = mapper;
		_mediator = mediator;
	}

	[HttpPost("v1/sign")]
	public async Task<IActionResult> Create([FromBody] CreateSignDto request) {
		var command = _mapper.Map<CreateSignCommand>(request);
		var result = await _mediator.Send(command);
		return Ok(result);
	}
}