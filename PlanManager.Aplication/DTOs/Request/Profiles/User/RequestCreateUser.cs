using PlanManager.Aplication.DTOs.Request.Profiles.Person;

namespace PlanManager.Aplication.DTOs.Request.Profiles.User;

public class RequestCreateUser
{
    public RequestCreatePerson Person { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public RequestCreateUser(RequestCreatePerson person, string username, string password)
    {
        Person = person;
        Username = username;
        Password = password;
    }
}