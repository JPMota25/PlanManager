using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities.Utils;

public class LogActivity : Entity {
	public Id User { get; init; }
	public User? FromUser { get; set; }
	public ELogType Type { get; init; }
	public EAction Action { get; init; }
	public ELogCode Code { get; init; }
	public Id ObjectId { get; init; }
	public Description Description { get; init; }

	public LogActivity() { }

	public LogActivity(Id user, ELogType type, EAction action, ELogCode code, Id objectId, Description description) {
		Type = type;
		User = user;
		Action = action;
		Code = code;
		ObjectId = objectId;
		Description = description;
	}
}