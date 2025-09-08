namespace PlanManager.Aplication.DTOs.Request.Profiles.User;

public class RequestLogin
{
    public string Username { get; set; }
    public string Password { get; set; }

    public RequestLogin(string username, string password)
    {
        Username = username;
        Password = password;
    }
}