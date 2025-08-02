using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;

namespace PlanManager.Domain.Entities.Utils;

public class LogActivity : Entity {
	public string User { get; init; }
	public User? FromUser { get; set; }
	public ELogType Type { get; init; }
	public EAction Action { get; init; }
	public ELogCode Code { get; init; }
	public string ObjectId { get; init; }
	public string Description { get; init; }

	public LogActivity() { }

	public LogActivity(string user, ELogType type, EAction action, ELogCode code, string objectId, string description) : base(true) {
		Type = type;
		User = user;
		Action = action;
		Code = code;
		ObjectId = objectId;
		Description = description;
	}
}