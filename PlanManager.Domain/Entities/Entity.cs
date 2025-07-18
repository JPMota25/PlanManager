using Flunt.Notifications;
using PlanManager.Domain.ValueObjects;

namespace PlanManager.Domain.Entities;

public class Entity : Notifiable<Notification> {
	protected void NewId() {
		Id = Id.New();
	}

	protected void EmptyId() {
		Id = Id.Empty;
	}

	protected void SetUpdatedAt() {
		UpdatedAt = DateTime.UtcNow;
	}

	public Id Id { get; private set; }
	public DateTime CreatedAt { get; private set; }
	public DateTime? UpdatedAt { get; private set; }

	protected Entity() {
		Id = Id.New();
		CreatedAt = DateTime.UtcNow;
	}
};