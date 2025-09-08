namespace PlanManager.Aplication.DTOs.Response.Profiles.User;

public class ResponseUserCreated
{
    public string Id { get; set; }
    public string Username { get; set; }

    public ResponseUserCreated(string id, string username)
    {
        Id = id;
        Username = username;
    }
}