namespace PlanManager.Aplication.DTOs.Response;

public class PersonCreatedDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public PersonCreatedDto(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}