using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Entities.PlanManager;

public class PlanPermissionRelation : Entity
{
    private void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public Company? Company { get; set; }
    public string IdCompany { get; private set; }
    public string IdPlanPermission { get; private set; }
    public PlanPermission? PlanPermission { get; set; }
    public string IdPlan { get; private set; }
    public Plan? Plan { get; set; }

    public PlanPermissionRelation() { }

    public PlanPermissionRelation(string idPlanPermission, string idPlan, string idCompany) : base(true)
    {
        IdPlanPermission = idPlanPermission;
        IdPlan = idPlan;
        IdCompany = idCompany;
    }
}