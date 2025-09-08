using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.Profiles.User.ChangePassword;
using PlanManager.Aplication.Commands.Profiles.User.CreateUser;
using PlanManager.Aplication.Commands.Profiles.User.Login;
using PlanManager.Aplication.Commands.Profiles.User.LoginReport;
using PlanManager.Aplication.DTOs.Request.Profiles;

namespace PlanManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("v1/login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var command = _mapper.Map<LoginCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("v1/register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto request)
    {
        var command = _mapper.Map<CreateUserCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("v1/changepassword")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
    {
        var command = _mapper.Map<ChangePasswordCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("v1/loginreport")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> LoginReport([FromBody] LoginReportQueryDto request)
    {
        var command = _mapper.Map<LoginReportCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}