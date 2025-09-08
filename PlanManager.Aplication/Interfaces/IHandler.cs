using PlanManager.Aplication.DTOs;
using PlanManager.Domain.Commands;

namespace PlanManager.Aplication.Interfaces;

public interface IHandler<TCommand, TResult> where TCommand : ICommand where TResult : class
{
    Task<ResultDto<TResult>> Handle(TCommand command);
}