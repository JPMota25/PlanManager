using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using PlanManager.Domain.Entities.Profiles;

namespace PlanManager.Domain.Entities.PlanManager;

public class Plan : Entity {
    public Plan(string name, decimal value, string idCompany) : base(true)
    {
        Name = name;
        Value = value;
        IdCompany = idCompany;
        Identification = Guid.NewGuid().ToString().Replace("-", "");
        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Notification>().Requires();
        AddNotifications(contract);
    }

    public void SetName(string name) {
		Name = name;
		Validate();
	}

	public void SetValue(decimal value) {
		Value = value;
		Validate();
	}

	public string Name { get; private set; }
	public decimal Value { get; private set; }
	public string Identification { get; private set; }
	public Company? Company { get; set; }
	public string IdCompany { get; init; }
	public IList<PlanPermissionRelation> Permissions { get; private set; } = new List<PlanPermissionRelation>();
	public Plan() { }

	
}