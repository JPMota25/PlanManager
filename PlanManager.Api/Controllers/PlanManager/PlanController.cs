using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlanManager.Aplication.Commands.PlanManager.Plans.CreatePlan;
using PlanManager.Aplication.Commands.PlanManager.Plans.PlanQuery;
using PlanManager.Aplication.DTOs.Request.PlanManager.Plan;

namespace PlanManager.Api.Controllers.PlanManager;

[ApiController]
[Route("api/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PlanController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("v1/create")]
    public async Task<IActionResult> Create([FromBody] CreatePlanDto request)
    {
        var command = _mapper.Map<CreatePlanCommand>(request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("v1/list")]
    public async Task<IActionResult> List([FromBody] PlanQueryDto request)
    {
        var command = _mapper.Map<PlanQueryCommand>(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}