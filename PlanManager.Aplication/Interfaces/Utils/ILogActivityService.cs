using PlanManager.Domain.Enums;

namespace PlanManager.Aplication.Interfaces.Utils;

public interface ILogActivityService
{
    Task CreateLog(ELogType type, EAction action, ELogCode code, string objectId, string description);
}