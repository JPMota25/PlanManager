using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Aplication.Interfaces.Utils;

public interface ILogActivityService {
	Task CreateLog(ELogType type, EAction action, ELogCode code, Id objectId, Description description);
}