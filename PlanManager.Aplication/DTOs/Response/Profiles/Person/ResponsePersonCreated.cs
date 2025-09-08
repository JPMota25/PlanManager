namespace PlanManager.Aplication.DTOs.Response.Profiles.Person;

public class ResponsePersonCreated
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public ResponsePersonCreated(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}