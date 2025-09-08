using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.Profiles.Customer.CreateCustomer;
using PlanManager.Aplication.DTOs.Request.Profiles.Customer;
using PlanManager.Shared.Authorization;

namespace PlanManager.Api.Controllers.Profiles;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomerController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Permission($"{Permissions.PlanManager.Profiles.Customer.Create}")]
    [HttpPost("v1/create")]
    public async Task<IActionResult> CreateCustomer([FromBody] RequestCreateCustomer request)
    {
        var command = _mapper.Map<CreateCustomerCommand>(request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}