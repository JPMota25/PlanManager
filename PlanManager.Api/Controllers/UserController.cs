using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.Profiles.User.ChangePassword;
using PlanManager.Aplication.Commands.Profiles.User.CreateUser;
using PlanManager.Aplication.Commands.Profiles.User.Login;
using PlanManager.Aplication.DTOs.Request.Profiles;

namespace PlanManager.Api.Controllers;

[ApiController]
public class UserController : ControllerBase {
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public UserController(IMediator mediator, IMapper mapper) {
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpPost("api/v1/login")]
	public async Task<IActionResult> Login([FromBody] LoginDto request) {
		var command = _mapper.Map<LoginCommand>(request);
		var response = await _mediator.Send(command);
		return Ok(response);
	}

	[HttpPost("api/v1/register")]
	public async Task<IActionResult> Register([FromBody] CreateUserDto request) {
		var command = _mapper.Map<CreateUserCommand>(request);
		var response = await _mediator.Send(command);
		return Ok(response);
	}

	[HttpPost("api/v1/changepassword")]
	[Authorize(Roles = "Admin")]
	public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request) {
		var command = _mapper.Map<ChangePasswordCommand>(request);
		var response = await _mediator.Send(command);
		return Ok(response);
	}
}