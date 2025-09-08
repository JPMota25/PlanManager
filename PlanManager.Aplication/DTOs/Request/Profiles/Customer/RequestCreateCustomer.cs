using PlanManager.Aplication.DTOs.Request.Profiles.Person;

namespace PlanManager.Aplication.DTOs.Request.Profiles.Customer;

public class RequestCreateCustomer
{
    public RequestCreatePerson Person { get; set; }
    public string IdCompany { get; set; }
}