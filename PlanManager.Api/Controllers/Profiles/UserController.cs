using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.Profiles.User.ChangePassword;
using PlanManager.Aplication.Commands.Profiles.User.CreateUser;
using PlanManager.Aplication.Commands.Profiles.User.Login;
using PlanManager.Aplication.Commands.Profiles.User.LoginReport;
using PlanManager.Aplication.DTOs.Request.Profiles;
using PlanManager.Aplication.DTOs.Request.Profiles.User;

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
    public async Task<IActionResult> Login([FromBody] RequestLogin request)
    {
        var command = _mapper.Map<LoginCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("v1/register")]
    public async Task<IActionResult> Register([FromBody] RequestCreateUser request)
    {
        var command = _mapper.Map<CreateUserCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("v1/changepassword")]
    public async Task<IActionResult> ChangePassword([FromBody] RequestChangePassword request)
    {
        var command = _mapper.Map<ChangePasswordCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("v1/loginreport")]
    public async Task<IActionResult> LoginReport([FromBody] RequestLoginReport request)
    {
        var command = _mapper.Map<LoginReportCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost()]
    public async Task<IActionResult> EditUser([FromBody] RequestEditUser request)
    {
        var command = _mapper.Map<EditUserCommand>(request);
        var response = await _mediator.Send(command);
    }
}