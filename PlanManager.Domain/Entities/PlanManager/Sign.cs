using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;
using PlanManager.Domain.Enums;
using System.Text;

namespace PlanManager.Domain.Entities.PlanManager;

public class Sign : Entity
{

    public void Approve()
    {
        Status = ESignStatus.Approved;
        Validate();
    }

    public void ActivateLicense()
    {
        Status = ESignStatus.Active;
        Validate();
    }

    public void GenerateToken()
    {
        if (Token != null) return;
        var bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString().Replace("-", "")[..32]);
        Token = Convert.ToBase64String(bytes);
    }

    public Sign(string idCustomer, string idCompany, string idPlan) : base(true)
    {
        IdCustomer = idCustomer;
        IdCompany = idCompany;
        IdPlan = idPlan;
        InitialTime = DateTime.UtcNow;
        Status = ESignStatus.PendingApproval;
        Identification = Guid.NewGuid().ToString().Replace("-", "");
        GenerateToken();
        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Notification>();
        AddNotifications(contract);
    }

    public void SetStatus(ESignStatus status)
    {
        Status = status;
    }

    public string IdCustomer { get; private set; }
    public Customer? Customer { get; set; }
    public string IdCompany { get; private set; }
    public Company? Company { get; set; }
    public Plan? Plan { get; set; }
    public string IdPlan { get; private set; }
    public string Token { get; private set; }
    public string Identification { get; private set; }
    public DateTime? InitialTime { get; init; }
    public ESignStatus Status { get; private set; }

    public Sign() { }
}