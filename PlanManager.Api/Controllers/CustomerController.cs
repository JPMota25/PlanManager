using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.CreateCustomer;
using PlanManager.Aplication.DTOs;
using PlanManager.Aplication.DTOs.Request;
using PlanManager.Aplication.DTOs.Response;

namespace PlanManager.Api.Controllers;

[ApiController]
[Route("api")]
public class CustomerController : ControllerBase {
	private readonly IMediator _mediator;
	private readonly IMapper  _mapper;

	public CustomerController(IMediator mediator, IMapper  mapper) {
		_mediator = mediator;
		_mapper =  mapper;
	}

	[HttpPost("v1/customer")]
	public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto request) {
		var command = _mapper.Map<CreateCustomerCommand>(request);
		ResultDto<PersonCreatedDto> result = await _mediator.Send(command);
		return Ok(result);
	}
}