using Flunt.Notifications;
using Flunt.Validations;
using System.Text;

namespace PlanManager.Domain.Entities.Profiles;

public class Customer : Entity
{
    public Customer(string idPerson, string idCompany) : base(true)
    {
        IdPerson = idPerson;
        IdCompany = idCompany;
        GenerateSecretToken();
        Identification = Guid.NewGuid().ToString().Replace("-", "");
        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Notification>();
        AddNotifications(contract);
    }

    public void GenerateSecretToken()
    {
        var bytes = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString().Replace("-", "")[..32]);
        SecretToken = Convert.ToBase64String(bytes);
    }

    public string IdPerson { get; private set; }
    public Person? Person { get; set; }
    public Company? Company { get; set; }
    public string IdCompany { get; private set; }
    public string Identification { get; private set; }
    public string SecretToken { get; private set; }
    public Customer() { }
}