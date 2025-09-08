using Flunt.Notifications;

namespace PlanManager.Domain.Entities;

public class Entity : Notifiable<Notification>
{
    public void SetUpdatedAt(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }
    protected Entity() { }

    public string Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected Entity(bool initialize)
    {
        if (initialize)
        {
            Id = Guid.NewGuid().ToString().Replace("-", "")[..11];
            CreatedAt = DateTime.UtcNow;
        }
    }
}