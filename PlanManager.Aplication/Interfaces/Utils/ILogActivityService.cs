using PlanManager.Domain.ValueObjects;
using SlotMe.Domain.Enums;

namespace PlanManager.Aplication.Interfaces.Utils;

public interface ILogActivityService {
	Task CreateLog(ELogType type, EAction action, ELogCode code, Id objectId, Description description);
}